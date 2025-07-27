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
        public async Task<AsistenciaCreateResponse?> RegistrarAsistenciaAsync(Asistencia asistencia)
        {
            if (asistencia == null)
            {
                return null;
            }
            AsistenciaCreateResponse response = await _asistenciaRepository.RegistrarAsync(asistencia);
            return response;
        }
    }
}