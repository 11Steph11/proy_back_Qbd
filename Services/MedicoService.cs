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
            Persona persona = _mapper.Map<Persona>(request.PersonaRequest);
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            MedicoCreateResponse response = new MedicoCreateResponse();
            bool existe = await _context.Medicos
                .AnyAsync(p => p.Cmp == request.Cmp);
            if (existe)
            {
                response.Msg ="Ya existe este CMP";
                return response;
            }
            Medico medico = _mapper.Map<Medico>(request);
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            response.Msg = "Creado Exitosamente";
            response.MedicoRes = medico;
            return response;
        }
        
        // public async Task<string?> Modificar(int id, MedicoUpdateReq request)
        // {
            
        //     Medicos? medico = await _context.Medicos.FindAsync(id);
        //     if (medico ==null)
        //     {
        //         return "no se encontró";
        //     }
        //     medico.Cmp = request.Cmp;
        //     medico.Datos = request.Datos;
        //     medico.Especialidad = request.Especialidad;
        //     medico.NumeroEspecialidad = request.NumeroEspecialidad;
        //     medico.Usuario = request.Usuario;
        //     await _context.SaveChangesAsync();
        //     return $"{id} fue actualizado";        
        // }
    }
}