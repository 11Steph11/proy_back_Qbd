using Proy_back_QBD.Dto.Productos;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IPedidoService
    {
        Task<PedidoCreateResponse?> Crear(PedidoCreateReq request);
        Task<PedidoUpdateResponse?> Actualizar(int id, PedidoUpdateReq request);
        Task<Pedido?> ActualizarPedido(int id, string boleta);
        Task<string?> ActualizarEstado(int id, string estado);
        Task<List<PedidoFindAllResponse?>> Obtener( int sedeId);
        
        Task<PedidoFindIdResponse?> ObtenerById(int id);
    }
}