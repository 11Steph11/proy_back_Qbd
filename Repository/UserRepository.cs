using Proy_back_QBD.Data;
using Proy_back_QBD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Proy_back_QBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Proy_back_QBD.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiContext _context;
        public UserRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerIdAsync(string dni)
        {
            var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(a => a.DNI.Equals(dni));
            return usuario;
        }
    }
}