using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Proy_back_QBD.Repository
{
    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly ApiContext _context;
        public AsistenciaRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Asistencia>?> ObtenerAsistenciasByIdAsync(string dni, int ano, int mes)
        {
            DateOnly Fecha = new DateOnly(ano, mes, 1);
            List<Asistencia> asistencia = await _context.Asistencias            
            .Include(a => a.Trabajador)
            .Where(a => a.Trabajador.DNI.Equals(dni) && a.FechaCreacion >= Fecha)
            .ToListAsync();            
            return asistencia;
        }

        public async Task<Asistencia?> RegistrarAsync(Asistencia asistencia)
        {
            _context.Asistencias.Add(asistencia);
            await _context.SaveChangesAsync();
            return asistencia;
        }

    }
}
