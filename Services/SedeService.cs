using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;

namespace Proy_back_QBD.Services
{
    public class SedeService : ISedeService
    {
        private readonly ApiContext _context;
        public SedeService(ApiContext context)
        {
            _context = context;
        }
        public async Task<int?> RegistrarSedeAsync(Sedes sede)
        {
            if (sede == null)
            {
                return null;
            }
            await _context.Sedes.AddAsync(sede);
            await _context.SaveChangesAsync();
            return sede.Id;
        }
    }
}