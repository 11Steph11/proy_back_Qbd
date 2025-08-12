using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;

namespace Proy_back_QBD.Services
{
    public interface IMedicoService
    {
       Task<int?> CrearMedico(MedicoCreateReq request);
        
    }
}