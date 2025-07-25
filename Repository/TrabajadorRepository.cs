using Proy_back_QBD.Data;
using Proy_back_QBD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Proy_back_QBD.Services;
using Microsoft.AspNetCore.Mvc;

namespace Proy_back_QBD.Repository
{
    public class TrabajadorRepository : ITrabajadorRepository
    {
        private readonly ApiContext _context;
        public TrabajadorRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<int?> RegistrarAsync(Trabajador trabajador)
        {
            _context.Trabajadores.AddAsync(trabajador);
            await _context.SaveChangesAsync();
            return trabajador.Id;
        }
    }
}