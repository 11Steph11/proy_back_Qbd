using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;

namespace Proy_back_QBD.Services
{
    public class RegionService : IRegionService
    {
        private readonly ApiContext _context;
        public RegionService(ApiContext context)
        {
            _context = context;
        }
        public async Task<int?> RegistrarSedeAsync(Sede sede)
        {
            if (sede == null)
            {
                return null;
            }
            await _context.Regions.AddAsync(sede);
            await _context.SaveChangesAsync();
            return sede.Id;
        }
    }
}