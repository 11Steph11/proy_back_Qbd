using Proy_back_QBD.Request;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;
using Proy_back_QBD.Models;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Dto.Response;

namespace Proy_back_QBD.Services
{
    public class SedeService : ISedeService
    {
        private readonly ApiContext _context;
        public SedeService(ApiContext context)
        {
            _context = context;
        }
        public async Task<Sede?> Crear(Sede sede)
        {
            await _context.Sedes.AddAsync(sede);
            await _context.SaveChangesAsync();
            return sede;
        }

        public async Task<List<SedeFindAllResponse?>> Obtener()
        {
            List<SedeFindAllResponse>? response = await _context.Sedes            
            .Select(a => new SedeFindAllResponse{
                Id = a.Id,
                Nombre = a.Nombre,
                Direccion = a.Direccion,
                Encargado = a.Encargado,
                Telefono = a.Telefono,
            }).ToListAsync();
            return response;
        }
    }
}