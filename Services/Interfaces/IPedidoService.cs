using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IPedidoService
    {
        Task<PedidoCreateResponse?> Crear(PedidoCreateReq request);
        Task<PedidoUpdateResponse?> Actualizar(int id, PedidoUpdateReq request);
        Task<Pedido?> Eliminar(int id);
        // Task<List<PedidoFindAllResponse?>> Obtener();
        // Task<PedidoFindIdResponse?> ObtenerById(int id);
    }
}