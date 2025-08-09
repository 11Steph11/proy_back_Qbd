using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IRegionService
    {
        Task<int?> RegistrarSedeAsync(Sede sede);
    }
}