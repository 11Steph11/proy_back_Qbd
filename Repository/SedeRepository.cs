using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;

namespace Proy_back_QBD.Repository
{
    public class SedeRepository:ISedeRepository
    {
        private readonly ApiContext _context;
        public SedeRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<int?> RegistrarAsync(Sede sede)
        {
            _context.Sedes.AddAsync(sede);
            await _context.SaveChangesAsync();
            return sede.Id;
        }
        
    }
}
