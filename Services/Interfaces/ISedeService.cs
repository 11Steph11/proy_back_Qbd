using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public interface ISedeService
    {
        Task<Sede?> RegistrarSede(Sede sede);
    }
}