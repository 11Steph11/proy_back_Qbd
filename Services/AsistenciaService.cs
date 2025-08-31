using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Data;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models;
using AutoMapper;
using Proy_back_QBD.Request;
using System.Diagnostics;

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

        // public async Task<AsistenciaByCodigoRes?> ListarPorCodigo(string codigo, int año, int mes)
        // {
        //     if (string.IsNullOrEmpty(codigo) || año <= 0 || mes <= 0 || mes > 12)
        //     {
        //         return null;
        //     }

        //     List<FechaConHoras>? lista = await _context.ObtenerAsistenciasAsync(codigo, año, mes);
        //     if (lista == null || lista.Count == 0)
        //     {
        //         return null;
        //     }
        //     AsistenciaByCodigoRes? response = await _context.Personas
        //         .Select(x => new AsistenciaByCodigoRes
        //         {
        //             NombreCompleto = x.Datos,
        //             Entrada = x.HoraEntrada,
        //             Almuerzo = x.HoraAlmuerzo,
        //             Regreso = x.HoraRegreso,
        //             Salida = x.HoraSalida
        //         }).FirstOrDefaultAsync();

        //     if (response == null)
        //     {
        //         return null;
        //     }
        //     response.Asistencias = lista;
        //     return response;
        // }


        public async Task<Asistencia?> Registrar(AsistenciaCreateReq request)
        {
            string? tipoAsistencia = request.Tipo;
            if (tipoAsistencia == null)
            {
                return null;
            }
            TimeOnly? horaAsignada = await _context.Usuarios
            .Where(a => a.Id == request.Creador)
            .Select(a =>tipoAsistencia.Equals("entrada")
                ? a.HorarioEntrada     // Si es "entrada", selecciona HorarioEntrada
                : (tipoAsistencia.Equals("salida")
                    ? a.HorarioSalida   // Si es "salida", selecciona HorarioSalida
                    : null // Si no es ni "entrada" ni "salida", devuelve el valor por defecto
                  )).FirstOrDefaultAsync();
            if (horaAsignada==null)
            {
                return null;
            }
            TimeSpan diferencia;            
            DateTime horaAsignada2 =DateTime.Today.Add(horaAsignada.GetValueOrDefault().ToTimeSpan());
            DateTime horaMarcada =DateTime.Now;
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
            }else{
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