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
            

            UsuarioLoginRes? response = await _context.Usuarios
            .Include(a => a.Trabajadores)
            .Include(a => a.Trabajadores.Sedes)
            .Where(a => a.Usuario == usuario)
            .Select(a => new UsuarioLoginRes
            {
                NombreCompleto = a.Trabajadores.Datos,
                Rol = a.Trabajadores.Rol,
                Contrasena = a.Password,
                Sede = a.Trabajadores.Sedes.Sede,
            })
            .FirstOrDefaultAsync();
            if (response == null)
            {
                return null;
            }
            if (!_authService.VerifyPassword(contrasena, response.Contrasena))
            {
                return null;
            }
            return response;
        }
    }
}