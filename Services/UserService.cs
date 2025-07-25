using Proy_back_QBD.Models;
using Proy_back_QBD.Repository;

namespace Proy_back_QBD.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthService _authService;
        public UserService(IUserRepository userRepository, AuthService authService) {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<Usuario?> ValidarLoginUserAsync(string dni, string contrasena)
        {
            var usuario = await _userRepository.ObtenerIdAsync(dni);
            if (usuario == null)
            {
                return null;
            }
            if (!_authService.VerifyPassword(contrasena,usuario.Contrasena)) {
                return null;
            }
            return usuario;
        }
    }
}