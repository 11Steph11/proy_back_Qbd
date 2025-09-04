using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public MedicoService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MedicoCreateResponse?> Crear(MedicoCreateReq request)
        {
            MedicoCreateResponse response = new MedicoCreateResponse();
            Persona persona = _mapper.Map<Persona>(request.PersonaCReq);
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            Medico medico = _mapper.Map<Medico>(request);
            bool existe = await _context.Medicos
                .AnyAsync(p => p.Cmp == request.Cmp);
            if (existe)
            {
                response.Msg = "Ya existe este CMP";
                return response;
            }
            
            medico.PersonaId = persona.Id; 
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            response.Msg = "Creado Exitosamente";
            response.MedicoRes = medico;
            return response;
        }

        public async Task<MedicoUpdateResponse?> Actualizar(int id, MedicoUpdateReq request)
        {
            MedicoUpdateResponse response = new MedicoUpdateResponse();
            Medico? medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                response.Msg = "no se encontró";
                return response;
            }
            _mapper.Map(request, medico);
            response.Msg = "Medico Actualizado";
            response.MedicoRes = medico;
            await _context.SaveChangesAsync();
            return response;
        }
        public async Task<Medico?> Eliminar(int id)
        {
            Medico? medico = await _context.Medicos
            .Include(a => a.PersonaFk)
            .FirstOrDefaultAsync(a => a.Id == id);
            _context.Remove(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<List<MedicoFindAllResponse?>> Obtener()
        {
            List<MedicoFindAllResponse>? response = await _context.Medicos
            .Include(a => a.Especialidad)
            .Include(a => a.PersonaFk)
            .Select(a => new MedicoFindAllResponse
            {
                EspecialidadFk = a.Especialidad.Nombre,
                NumeroEspecialidad = a.NumeroEspecialidad,
                NombreCompleto = $"{a.PersonaFk.Nombres} {a.PersonaFk.ApellidoPaterno} {a.PersonaFk.ApellidoMaterno}",
                Cmp = a.Cmp
            })
            .ToListAsync();

            if (response == null)
            {
                return null;
            }
            return response;
        }
        public async Task<MedicoFindIdResponse?> ObtenerById(int id)
        {
            MedicoFindIdResponse? response = await _context.Medicos
            .Include(a => a.Especialidad)
            .Include(a => a.PersonaFk)
            .Where(a => a.Id == id)
            .Select(a => new MedicoFindIdResponse
            {
                Id = a.Id,
                EspecialidadId = a.EspecialidadId,
                NumeroEspecialidad = a.NumeroEspecialidad,
                PersonaFk = _mapper.Map<PersonaRes>(a.PersonaFk),
                Cmp = a.Cmp,
            })
            .FirstAsync();

            if (response == null)
            {
                return null;
            }
            return response;
        }
    }
}