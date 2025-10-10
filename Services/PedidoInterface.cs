using Proy_back_QBD.Dto.Productos;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IPedidoService
    {
        Task<PedidoCreateRes?> Crear(PedidoCreateReq request);
        Task<PedidoUpdateResponse?> Actualizar(int id, PedidoUpdateReq request);
        Task<Pedido?> ActComprobante(int id, string? boleta);
        Task<string?> ActEstado(int id, string estado);
        Task<List<PedidoFindAllResponse?>> Listar( int sedeId);
        Task<List<PedidoLabFindAllRes2?>> ListarLab( int sedeId);
        Task<PedidoFindIdResponse?> ObtenerById(int id);
    }
}