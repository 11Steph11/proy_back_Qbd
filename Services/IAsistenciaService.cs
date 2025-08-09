using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IAsistenciaService
    {
        // Task<AsistenciaByDNIResponse?> ObtenerAsistenciasByIdAsync(string dni, int año, string mes);
        Task<AsistenciaCreateRes?> RegistrarAsistenciaAsync(Asistencia asistencia);
    }
}