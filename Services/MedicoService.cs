using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

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

        public async Task<string?> CrearMedico(MedicoCreateReq request)
        {
            if (request == null)
            {
                return null;
            }
            Medicos medico = _mapper.Map<Medicos>(request);
            await _context.Medicos.AddAsync(medico);
            return $"{medico.Id} fue creado";        
        }

    }
}