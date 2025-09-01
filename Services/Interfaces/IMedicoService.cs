using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IMedicoService
    {
       Task<MedicoCreateResponse?> Crear(MedicoCreateReq request);
    //    Task<string?> Modificar(int id, MedicoUpdateReq request);
        
    }
}