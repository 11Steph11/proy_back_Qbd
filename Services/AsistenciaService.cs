using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Data;
using Microsoft.EntityFrameworkCore;

namespace Proy_back_QBD.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly ApiContext _context;
        public AsistenciaService(ApiContext context)
        {
            _context = context;
        }

        // DateOnly Fecha = new DateOnly(ano, mes, 1);
        //     List<Asistencia> asistencia = await _context.Asistencias            
        //     .Include(a => a.Trabajador)
        //     .Where(a => a.Trabajador.DNI.Equals(dni) && a.FechaCreacion >= Fecha)
        //     .ToListAsync();            
        //     return asistencia;

        // public async Task<AsistenciaByDNIResponse?> ObtenerAsistenciasByIdAsync(string dni, int año, string mes)
        // {
        //     List<Asistencia>? lista = await _asistenciaRepository.ObtenerAsistenciasByIdAsync(idTrabajador);

        //     return ;

        // }

        public async Task<AsistenciaCreateRes?> RegistrarAsistenciaAsync(Asistencia asistencia)
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