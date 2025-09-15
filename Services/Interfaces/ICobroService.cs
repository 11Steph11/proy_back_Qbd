using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public interface ICobroService
    {
        Task<Cobro?> Crear(CobroCreateReq request);
        Task<Cobro?> Actualizar(int id, CobroUpdateReq request);
        // Task<Cobro?> Eliminar(int id);
        // Task<List<CobroFindAllResponse?>> Obtener();
        // Task<CobroFindIdResponse?> ObtenerById(int id);
    }
}