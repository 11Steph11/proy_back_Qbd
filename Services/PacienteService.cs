using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
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
        public async Task<string?> Crear(PacienteCreateReq request)
        {
            Paciente paciente = _mapper.Map<Paciente>(request);
            bool existe = await _context.Pacientes
                .AnyAsync(p => p.DNI == request.DNI);
            if (existe)
            {
                return "El paciente ya existe.";
            }
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return "Paciente creado exitosamente.";
        }
    }
}