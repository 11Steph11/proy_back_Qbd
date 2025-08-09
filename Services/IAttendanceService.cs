using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IAttendanceService
    {
        // Task<AsistenciaByDNIResponse?> ObtenerAsistenciasByIdAsync(string dni, int año, string mes);
        Task<AttendanceCreateRes?> RegistrarAsistenciaAsync(Asistencia asistencia);
    }
}