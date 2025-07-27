using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Response;

namespace Proy_back_QBD.Repository
{
    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly ApiContext _context;
        public AsistenciaRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<AsistenciaCreateResponse?> RegistrarAsync(Asistencia asistencia)
        {
            _context.Asistencias.AddAsync(asistencia);
            await _context.SaveChangesAsync();
            AsistenciaCreateResponse response = new AsistenciaCreateResponse();
            response.HoraMarcada = asistencia.HoraMarcada ?? TimeOnly.FromDateTime(DateTime.Now);
            if (asistencia.HoraAsignada.HasValue)
            {
                var diferencia = response.HoraMarcada - asistencia.HoraAsignada.Value;

                // Asignar la diferencia a la propiedad de la entidad Asistencia
                response.Diferencia = diferencia; 
            }
            response.Id = asistencia.Id;
            return response;
        }

    }
}
