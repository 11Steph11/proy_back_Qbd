using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Proy_back_QBD.Repository
{
    public interface ITrabajadorRepository
    {
        Task<int?> RegistrarAsync(Trabajador trabajador);
    }
}
