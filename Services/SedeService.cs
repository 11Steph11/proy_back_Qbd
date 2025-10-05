using Proy_back_QBD.Request;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;
using Proy_back_QBD.Models;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Dto.Response;
using Microsoft.AspNetCore.Http.HttpResults;

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
            .Select(a => new SedeFindAllResponse
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Direccion = a.Direccion,
                Encargado = a.Encargado,
                Telefono = a.Telefono,
            }).ToListAsync();
            return response;
        }

        public async Task<GeneralRes?> ObtGeneral(int id)
        {
            GeneralRes? response = await _context.Sedes
                        .Where(w => w.Id == id)
                        .Select(s => new GeneralRes
                        {
                            Meta = s.Meta,
                            MsgGpt = s.MsgGpt,
                            MsgWsp = s.MsgWsp
                        }).FirstOrDefaultAsync();

            if (response == null)
            {
                return null;
            }

            return response;
        }

        public async Task<string?> ActualizarGeneral(int id, GeneralReq request)
        {
            var entidad = await _context.Sedes.FirstOrDefaultAsync(f => f.Id == id);
            if (entidad == null)
            {
                return null;
            }
            if (request.MsgWsp != null)
            {
                entidad.MsgWsp = request.MsgWsp;
            }

            if (request.MsgGpt != null)
            {
                entidad.MsgGpt = request.MsgGpt;
            }
            if (request.Meta != null)
            {
                entidad.Meta = request.Meta;
            }

            _context.Sedes.Update(entidad);
            await _context.SaveChangesAsync();

            return "registro exitoso";
        }

    }
}