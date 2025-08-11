using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public class UserService : IUserService
    {
        private readonly ApiContext _context;
        private readonly AuthService _authService;
        public UserService(ApiContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        public async Task<UsuarioLoginRes?> ValidarLoginUserAsync(string usuario, string contrasena)
        {


            UsuarioLoginDataRes? data = await (from u in _context.Usuarios
                                               join t in _context.Trabajadores on u.Usuario equals t.Codigo
                                               join s in _context.Sedes on t.IdSede equals s.Id
                                               where u.Usuario == usuario
                                               select new UsuarioLoginDataRes
                                               {
                                                   NombreCompleto = t.Datos,
                                                   Rol = t.Rol,
                                                   Contrasena = u.Password,
                                                   Sede = s.Sede
                                               })
                                   .FirstOrDefaultAsync();
            if (data == null)
            {
                return null;
            }

            if (!_authService.VerifyPassword(contrasena, data.Contrasena))
            {
                return null;
            }
            UsuarioLoginRes response = new UsuarioLoginRes
            {
                NombreCompleto = data.NombreCompleto,
                Rol = data.Rol,
                Sede = data.Sede,
            };
            return response;
        }
    }
}