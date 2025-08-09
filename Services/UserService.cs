using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
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
        public async Task<Usuario?> ValidarLoginUserAsync(string dni, string contrasena)
        {
            var usuario = await _context.Users
            .Include(a => a.Tipo)
            .Include(a => a.Sede)
            .FirstOrDefaultAsync(a => a.DNI.Equals(dni));
            
            if (usuario == null)
            {
                return null;
            }
            if (!_authService.VerifyPassword(contrasena, usuario.Contrasena))
            {
                return null;
            }
            return usuario;
        }
    }
}