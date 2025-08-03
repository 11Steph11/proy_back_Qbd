using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Repository;
using Proy_back_QBD.Dto.Response;

namespace Proy_back_QBD.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly IAsistenciaRepository _asistenciaRepository;
        public AsistenciaService(IAsistenciaRepository asistenciaRepository)
        {
            _asistenciaRepository = asistenciaRepository;
        }

        // public async Task<AsistenciaByDNIResponse?> ObtenerAsistenciasByIdAsync(string dni, int año, string mes)
        // {
        //     List<Asistencia>? lista = await _asistenciaRepository.ObtenerAsistenciasByIdAsync(idTrabajador);

        //     return ;

        // }

        public async Task<AsistenciaCreateResponse?> RegistrarAsistenciaAsync(Asistencia asistencia)
        {
            if (asistencia == null)
            {
                return null;
            }
            AsistenciaCreateResponse response = new AsistenciaCreateResponse();
            Asistencia asistenciaResponse = await _asistenciaRepository.RegistrarAsync(asistencia);
            response.HoraMarcada = asistenciaResponse.HoraMarcada ?? TimeOnly.FromDateTime(DateTime.Now);
            if (asistenciaResponse.HoraAsignada.HasValue)
            {
                var diferencia = response.HoraMarcada - asistenciaResponse.HoraAsignada.Value;
                // Asignar la diferencia a la propiedad de la entidad Asistencia
                response.Diferencia = diferencia;
            }
            return response;
        }

    }
}