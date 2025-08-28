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
        public async Task<UsuarioLoginDataRes?> ValidarLoginUserAsync(string usuario, string contrasena)
        {


            UsuarioLoginDataRes? response = await _context.Usuarios
            .Include(a => a.Persona)
            .Include(a => a.Persona.Sede)
            .Include(a => a.Tipo)
            .Select(a => new UsuarioLoginDataRes
            {
                NombreCompleto = $"{a.Persona.Nombres} {a.Persona.ApellidoPaterno} {a.Persona.ApellidoMaterno}",
                TipoUsuario = a.Tipo.Nombre,
                TipoId = a.Tipo.Id,
                Sede = a.Persona.Sede.Nombre,
                Id = a.Id,
            })
            .FirstOrDefaultAsync();
            if (response == null)
            {
                return null;
            }

            return response;
        }
    }
}