using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IFormulaService
    {
        Task<FormulaCreateResponse?> CrearFormPed(FormulaCreateReq request);        
        Task<FormulaUpdateResponse?> Actualizar(int formulaId, FormulaUpdateReq request);
        Task<Formula?> ActualizarLab(int formulaId, FormulaUpdLabReq request);
        Task<List<RecetaRes>?> ListarReceta(int sedeId);
        Task<Formula?> Eliminar(int id);
        Task<string?> AgregarInserto(int id, string inserto);
        Task<Formula> ActualizarFormulaM(int formulaId, string FormulaMagistral);
        Task<FormulasLab?> ListarFormulasLab(int pedidoId);
        Task<EtiquetaRes?> ObtenerEtiqueta(int formulaId);
        Task<DetallesRes?> ObtenerDetalles(int formulaId);
    }
}