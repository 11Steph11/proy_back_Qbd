using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface ISedeService
    {
        Task<Sede?> RegistrarSede(Sede sede);
    }
}