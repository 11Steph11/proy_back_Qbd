using System.Globalization;
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
            Paciente? paciente = await _context.Pacientes
                                                .Include(i => i.Persona)
                                                .FirstOrDefaultAsync(fod => fod.Id == id);
            if (paciente == null)
            {
                response.Msg = "no se encontró";
                return response;
            }
            _mapper.Map(request, paciente);
            _mapper.Map(request.Persona, paciente.Persona);
            response.Msg = "Paciente Actualizado";
            response.PacienteRes = paciente;
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<PacienteCreateResponse?> Crear(PacienteCreateReq request)
        {
            PacienteCreateResponse response = new PacienteCreateResponse();
            Persona persona = _mapper.Map<Persona>(request.Persona);
            persona.ModificadorId = persona.CreadorId;
            Paciente paciente = _mapper.Map<Paciente>(request);
            bool existe = await _context.Pacientes
                .AnyAsync(p => p.Persona.Dni == request.Persona.Dni);
            if (existe)
            {
                response.Msg = "El paciente ya existe.";
                return response;
            }
            paciente.PersonaId = persona.Id;
            paciente.ModificadorId = paciente.CreadorId;
            response.PacienteRes = paciente;
            response.Msg = "Paciente creado exitosamente.";
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<Paciente?> Eliminar(int id)
        {
            Paciente? paciente = await _context.Pacientes
           .Include(a => a.Persona)
           .FirstOrDefaultAsync(a => a.Id == id);
            _context.Remove(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<List<PacienteFindAllResponse?>> Obtener()
        {


            var query = _context.Pacientes
                .Include(a => a.Persona)
                .Select(a => new PacienteFindAllResponse
                {
                    Id = a.Id,
                    DniApoderado = a.DniApoderado,
                    NombreCompleto = $"{a.Persona.NombreCompleto}",
                    Edad = CalcularEdad(a.Persona.FechaNacimiento),
                    Apoderado = a.Apoderado,
                    Persona = _mapper.Map<PersonaRes2>(a.Persona),
                    Telefono = a.Persona.Telefono,
                    CondicionFecha = a.CondicionFecha,
                    FechaCumple = $"{a.Persona.FechaNacimiento.GetValueOrDefault().Day} de {a.Persona.FechaNacimiento.GetValueOrDefault().ToString("MMMM", new CultureInfo("es-ES"))}",
                });

            var response = await query
                .ToListAsync();

            return response ?? new List<PacienteFindAllResponse?>();
        }

        public async Task<PacienteFindIdResponse?> ObtenerById(int id)
        {
            PacienteFindIdResponse? response = await _context.Pacientes
            .Include(i => i.Persona)
           .Where(a => a.Id == id)
           .Select(a => new PacienteFindIdResponse
           {
               Id = a.Id,
               Apoderado = a.Apoderado,
               DniApoderado = a.DniApoderado,
               Direccion = a.Persona.Direccion,
               PersonaFk = _mapper.Map<PersonaRes>(a.Persona),
               CondicionFecha = a.CondicionFecha,
           })
           .FirstAsync();

            if (response == null)
            {
                return null;
            }
            return response;
        }

        public static string CalcularEdad(DateOnly? fechaNacimiento)
        {
            var hoy = DateOnly.FromDateTime(DateTime.Today);

            int num = hoy.Year - fechaNacimiento.GetValueOrDefault().Year;
            string edad;

            if (fechaNacimiento > hoy.AddYears(-num))
            {
                num--;

            }
            edad = num + " años";
            if (num == 1)
            {
                edad = num + " año";
            }

            if (num == 0)
            {
                num = 12 - fechaNacimiento.GetValueOrDefault().Month;
                edad = num + " meses";
            }

            return edad;
        }
    }
}