using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IFormulaCCService
    {
        Task<List<RecetaRes>?> ListarInsumos(int sedeId);
        Task<FormulaCCLabRes>? ListarInsumosLab(int formulaId, int sedeId);
        Task<List<FormulaCC>>? Actualizar(int formulaId, int sedeId, FormulaCCUpdReqP formulas);
    }
}