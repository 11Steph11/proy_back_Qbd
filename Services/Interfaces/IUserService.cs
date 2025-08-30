using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public interface IUserService
    {
        Task<UsuarioLoginDataRes?> ValidarLogin(string usuario, string contrasena);
        Task<Usuario?> Crear(UsuarioCreateReq request);
        Task<Usuario?> Eliminar(int id);
        Task<Usuario?> Actualizar(int id, UsuarioUpdateReq request);
    }
}