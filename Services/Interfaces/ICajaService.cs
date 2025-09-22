using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;
using Proy_back_QBD.Response;

namespace Proy_back_QBD.Services
{
    public interface ICajaService
    {
        Task<CajaFindAllRes?> Obtener(CajaFindAllReq request);
    }
}