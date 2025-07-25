using BCrypt.Net;
using System;

namespace Proy_back_QBD.Services
{
    public class AuthService
    {
        // Método para hashear la contraseña
        public string HashPassword(string plainPassword)
        {
            // Usamos bcrypt para generar un hash de la contraseña
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            return hashedPassword;
        }

        // Método para verificar la contraseña
        public bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            // Comparamos la contraseña ingresada con el hash almacenado
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }

}