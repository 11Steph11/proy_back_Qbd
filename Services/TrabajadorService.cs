using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Repository;

namespace Proy_back_QBD.Services
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly ITrabajadorRepository _trabajadorRepository;
        private readonly AuthService _authService;
        public TrabajadorService(ITrabajadorRepository trabajadorRepository, AuthService authService)
        {
            _trabajadorRepository = trabajadorRepository;
            _authService = authService;
        }
        public async Task<int?> RegistrarTrabajadorAsync(Trabajador trabajador)
        {
            if (trabajador == null)
            {
                return null;
            }
            trabajador.Contrasena = _authService.HashPassword(trabajador.Contrasena);
            await _trabajadorRepository.RegistrarAsync(trabajador);
            return trabajador.Id;
        }
    }
}