using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IUserService
    {
        Task<UsuarioLoginDataRes?> ValidarLogin(string usuario, string contrasena);
        Task<Usuario?> Crear(UsuarioCreate request);
    }
}