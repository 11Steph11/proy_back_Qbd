using Proy_back_QBD.Dto.Auxiliares;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IFormulaRService
    {
        Task<List<FormulaRRes>?> ListaFormulaR(int sedeId);
    }
}