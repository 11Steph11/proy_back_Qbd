using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Proy_back_QBD.Repository
{
    public interface ISedeRepository
    {
        Task<int?> RegistrarAsync(Sede sede);
    }
}
