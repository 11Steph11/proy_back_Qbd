using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface ISedeService
    {
        Task<int?> RegistrarSedeAsync(Sede sede);
    }
}