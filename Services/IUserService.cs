using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IUserService
    {
        Task<User?> ValidarLoginUserAsync(string dni, string contrasena);
        
    }
}