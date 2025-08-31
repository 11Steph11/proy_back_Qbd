using Proy_back_QBD.Request;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public class SedeService : ISedeService
    {
        private readonly ApiContext _context;
        public SedeService(ApiContext context)
        {
            _context = context;
        }
        public async Task<Sede?> RegistrarSede(Sede sede)
        {
            await _context.Sedes.AddAsync(sede);
            await _context.SaveChangesAsync();
            return sede;
        }
    }
}