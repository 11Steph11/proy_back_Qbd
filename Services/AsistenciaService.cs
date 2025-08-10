using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Data;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Dto.Request;

namespace Proy_back_QBD.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly ApiContext _context;
        public AsistenciaService(ApiContext context)
        {
            _context = context;
        }

        public async Task<AsistenciaByCodigoRes?> ListarPorCodigo(string codigo, int año, int mes)
        {
            if (string.IsNullOrEmpty(codigo) || año <= 0 || mes <= 0 || mes > 12)
            {
                return null;
            }

            List<FechaConHoras>? lista = await _context.ObtenerAsistenciasAsync(codigo, año, mes);
            if (lista == null || lista.Count == 0)
            {
                return null;
            }
            AsistenciaByCodigoRes? response = await _context.Trabajador
                .Where(x => x.Codigo == codigo)
                .Select(x => new AsistenciaByCodigoRes
                {
                    NombreCompleto = $"{x.Nombres} {x.ApellidoPaterno} {x.ApellidoMaterno}",
                    Entrada = x.HoraEntrada,
                    Almuerzo = x.HoraAlmuerzo,
                    Regreso = x.HoraRegreso,
                    Salida = x.HoraSalida
                }).FirstOrDefaultAsync();

            if (response == null)
            {
                return null;
            }
            response.Asistencias = lista;
            return response;
        }


        public async Task<AsistenciaCreateRes?> Registrar(Asistencia asistencia)
        {

            if (asistencia == null)
            {
                return null;
            }
            AsistenciaCreateRes response = new AsistenciaCreateRes();

            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();

            response.HoraMarcada = asistencia.HoraMarcada ?? TimeOnly.FromDateTime(DateTime.Now);
            if (asistencia.HoraAsignada.HasValue)
            {
                var diferencia = response.HoraMarcada - asistencia.HoraAsignada.Value;
                response.Diferencia = diferencia;
            }
            return response;
        }

    }
}