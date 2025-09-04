using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public PacienteService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PacienteUpdateResponse?> Actualizar(int id, PacienteUpdateReq request)
        {
            PacienteUpdateResponse response = new PacienteUpdateResponse();
            Paciente? paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                response.Msg = "no se encontró";
                return response;
            }
            _mapper.Map(request, paciente);
            response.Msg = "Paciente Actualizado";
            response.PacienteRes = paciente;
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<PacienteCreateResponse?> Crear(PacienteCreateReq request)
        {
            PacienteCreateResponse response = new PacienteCreateResponse();
            Persona persona = _mapper.Map<Persona>(request.PersonaFk);
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            Paciente paciente = _mapper.Map<Paciente>(request);
            bool existe = await _context.Pacientes
                .AnyAsync(p => p.PersonaFk.Dni == request.PersonaFk.Dni);
            if (existe)
            {
                response.Msg = "El paciente ya existe.";
                return response;
            }
            paciente.PersonaId = persona.Id;

            response.PacienteRes = paciente;
            response.Msg = "Paciente creado exitosamente.";
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<Paciente?> Eliminar(int id)
        {
            Paciente? paciente = await _context.Pacientes
           .Include(a => a.PersonaFk)
           .FirstOrDefaultAsync(a => a.Id == id);
            _context.Remove(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<List<PacienteFindAllResponse?>> Obtener()
        {
            List<PacienteFindAllResponse>? response = await _context.Pacientes
            .Include(a => a.PersonaFk)
            .Select(a => new PacienteFindAllResponse
            {
                Id = a.Id,
                NombreCompleto = $"{a.PersonaFk.Nombres} {a.PersonaFk.ApellidoPaterno} {a.PersonaFk.ApellidoMaterno}",
                Apoderado = a.Apoderado,
                DniApoderado = a.DniApoderado,
            })
            .ToListAsync();

            if (response == null)
            {
                return null;
            }
            return response;
        }

        public async Task<PacienteFindIdResponse?> ObtenerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}