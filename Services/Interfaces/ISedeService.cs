using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public interface ISedeService
    {
        Task<Sede?> Crear(Sede request);
        // Task<SedeUpdateResponse?> Actualizar(int id, SedeUpdateReq request);
        // Task<Sede?> Eliminar(int id);
        Task<List<SedeFindAllResponse?>> Obtener();
        // Task<SedeFindIdResponse?> ObtenerById(int id);
    }
}