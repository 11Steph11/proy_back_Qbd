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

        public async Task<string?> Crear(MedicoCreateReq request)
        {
            bool existe = await _context.Medicos
                .AnyAsync(p => p.Cmp == request.Cmp);
            if (existe)
            {
                return "El médico ya existe.";
            }
            Medicos medico = _mapper.Map<Medicos>(request);
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            return $"{medico.Id} fue creado";
        }
        
        public async Task<string?> Modificar(int id, MedicoUpdateReq request)
        {
            
            Medicos? medico = await _context.Medicos.FindAsync(id);
            if (medico ==null)
            {
                return "no se encontró";
            }
            medico.Cmp = request.Cmp;
            medico.Datos = request.Datos;
            medico.Especialidad = request.Especialidad;
            medico.NumeroEspecialidad = request.NumeroEspecialidad;
            medico.Usuario = request.Usuario;
            await _context.SaveChangesAsync();
            return $"{id} fue actualizado";        
        }
    }
}