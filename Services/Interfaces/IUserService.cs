using Proy_back_QBD.Dto.Response;

namespace Proy_back_QBD.Services
{
    public interface IUserService
    {
        Task<UsuarioLoginDataRes?> ValidarLoginUserAsync(string usuario, string contrasena);
        
    }
}