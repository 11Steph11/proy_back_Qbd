using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;
using Proy_back_QBD.Response.Proy_back_QBD.Dto.Response;

namespace Proy_back_QBD.Services
{
    public interface ICobroService
    {
        Task<CobroCreateRes?> Crear(CobroCreateReq request);
        Task<CobroCreateRes?> Actualizar(int id, CobroUpdateReq request);
        // Task<Cobro?> Eliminar(int id);
        Task<List<CobroByPedido?>> Obtener(int PedidoId);
        // Task<CobroFindIdResponse?> ObtenerById(int id);
    }
}