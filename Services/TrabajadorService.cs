using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;

namespace Proy_back_QBD.Services
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly AuthService _authService;
        private readonly ApiContext _context;
        public TrabajadorService(ApiContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        public async Task<int?> RegistrarTrabajadorAsync(Trabajador trabajador)
        {
            if (trabajador == null)
            {
                return null;
            }
            trabajador.Contrasena = _authService.HashPassword(trabajador.Contrasena);
            _context.Trabajadores.AddAsync(trabajador);
            await _context.SaveChangesAsync();
            return trabajador.Id;
        }
    }
}