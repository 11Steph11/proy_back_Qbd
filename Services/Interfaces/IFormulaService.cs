using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IFormulaService
    {
        Task<FormulaCreateResponse?> Crear(FormulaCreateReq request);
        // Task<FormulaUpdateResponse?> Actualizar(int id, FormulaUpdateReq request);
        // Task<Formula?> Eliminar(int id);
        // Task<List<FormulaFindAllResponse?>> Obtener();
        // Task<FormulaFindIdResponse?> ObtenerById(int id);
    }
}