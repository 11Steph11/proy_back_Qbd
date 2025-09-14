using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IProdTermService
    {
        Task<ProdTerm?> Crear(ProdTermCreateReq request);
        Task<ProdTerm?> Actualizar(int id, ProdTermUpdateReq request);
        Task<ProdTerm?> Eliminar(int id);
        // Task<List<PedidoFindAllResponse?>> Obtener();
        // Task<PedidoFindIdResponse?> ObtenerById(int id);
    }
}