using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Data;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models;
using AutoMapper;
using Proy_back_QBD.Request;
using System.Diagnostics;
using System.Globalization;

namespace Proy_back_QBD.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public AsistenciaService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<AsistenciaByIdRes?> ObtenerPorId(int id, int año, int mes)
        {
            if (id == null || año <= 0 || mes <= 0 || mes > 12)
            {
                return null;
            }
            DateTime? fechaFiltro = new DateTime(año, mes, 1, 0, 0, 0, DateTimeKind.Utc);
            var lista = await _context.Asistencias
                .Where(a => a.Creador == id && a.FechaCreacion >= fechaFiltro)
                .GroupBy(a => a.FechaCreacion.Value.Date)
                .Select(g => new FechaConHoras
                {
                    Dia = g.Key.ToString("dddd", new CultureInfo("es-ES")),

                    HoraEntrada = g.Where(x => x.Tipo == "entrada")
                       .OrderBy(x => x.HoraMarcada)
                       .Select(x => x.HoraMarcada.ToString())
                       .FirstOrDefault(),

                    HoraSalida = g.Where(x => x.Tipo == "salida")
                      .OrderByDescending(x => x.HoraMarcada)
                      .Select(x => x.HoraMarcada.ToString())
                      .FirstOrDefault(),
                })
                .ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return null;
            }

            AsistenciaByIdRes? response = await _context.Usuarios
                .Include(a => a.Persona)
                .Select(a => new AsistenciaByIdRes
                {
                    NombreCompleto = $"{a.Persona.Nombres} {a.Persona.Apellidos}",
                    Entrada = a.HorarioEntrada,
                    Salida = a.HorarioSalida,
                    Almuerzo = a.HorarioAlmuerzo,
                    Regreso = a.HorarioRegreso,
                    Asistencias = lista
                }).FirstOrDefaultAsync();

            if (response == null)
            {
                return null;
            }
            response.Asistencias = lista;
            return response;
        }


        public async Task<Asistencia?> Crear(AsistenciaCreateReq request)
        {
            string? tipoAsistencia = request.Tipo;
            if (tipoAsistencia == null)
            {
                return null;
            }
            TimeOnly? horaAsignada = await _context.Usuarios
            .Where(a => a.Id == request.Creador)
            .Select(a => tipoAsistencia.Equals("entrada")
                ? a.HorarioEntrada     // Si es "entrada", selecciona HorarioEntrada
                : (tipoAsistencia.Equals("salida")
                    ? a.HorarioSalida   // Si es "salida", selecciona HorarioSalida
                    : null // Si no es ni "entrada" ni "salida", devuelve el valor por defecto
                  )).FirstOrDefaultAsync();
            if (horaAsignada == null)
            {
                return null;
            }
            TimeSpan diferencia;
            DateTime horaAsignada2 = DateTime.Today.Add(horaAsignada.GetValueOrDefault().ToTimeSpan());
            DateTime horaMarcada = DateTime.Now;
            Asistencia asistencia = _mapper.Map<Asistencia>(request);
            diferencia = (horaAsignada2 - horaMarcada).Duration();
            Debug.WriteLine(diferencia);
            if (tipoAsistencia.Equals("entrada") && horaMarcada > horaAsignada2)
            {
                asistencia.TiempoAtraso = diferencia;
            }
            else
            {
                asistencia.TiempoExtra = diferencia;
            }
            if (tipoAsistencia.Equals("salida") && horaMarcada > horaAsignada2)
            {
                asistencia.TiempoExtra = diferencia;
            }
            else
            {
                asistencia.TiempoAtraso = diferencia;
            }
            asistencia.HoraMarcada = TimeOnly.FromDateTime(horaMarcada);
            asistencia.HoraAsignada = horaAsignada;
            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();
            return asistencia;
        }

    }
}