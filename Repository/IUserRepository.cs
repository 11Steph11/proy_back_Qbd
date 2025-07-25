using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Proy_back_QBD.Repository
{
    public interface IUserRepository
    {
        Task<Usuario?> ObtenerIdAsync(string id);
    }
}
