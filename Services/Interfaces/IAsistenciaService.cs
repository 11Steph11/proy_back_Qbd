using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public interface IAsistenciaService
    {
        // Task<AsistenciaByDNIResponse?> ObtenerAsistenciasByIdAsync(string dni, int año, string mes);
        Task<Asistencia?> Registrar(AsistenciaCreateReq asistencia);
        // Task<AsistenciaByCodigoRes?> ListarPorCodigo(string codigo, int año, int mes);
    }
}