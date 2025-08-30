using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class UserService : IUserService
    {
        private readonly ApiContext _context;
        private readonly IMapper   _mapper;
        public UserService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UsuarioLoginDataRes?> ValidarLogin(string usuario, string contrasena)
        {


            UsuarioLoginDataRes? response = await _context.Usuarios
            .Include(a => a.Persona)
            .Include(a => a.Persona.Sede)
            .Include(a => a.Tipo)
            .Select(a => new UsuarioLoginDataRes
            {
                NombreCompleto = $"{a.Persona.Nombres} {a.Persona.ApellidoPaterno} {a.Persona.ApellidoMaterno}",
                TipoUsuario = a.Tipo.Nombre,
                TipoId = a.Tipo.Id,
                Sede = a.Persona.Sede.Nombre,
                Id = a.Id,
            })
            .FirstOrDefaultAsync();
            if (response == null)
            {
                return null;
            }

            return response;
        }
        public async Task<Usuario?> Crear(UsuarioCreateReq request)
        {
            Persona persona = _mapper.Map<Persona>(request);
            await _context.Personas.AddAsync(persona);
            Usuario usuario = _mapper.Map<Usuario>(request);
            await _context.SaveChangesAsync();
            usuario.PersonaId = persona.Id;
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        public async Task<Usuario?> Eliminar(int id)
        {
            Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(a => a.Id == id);
            if (usuario == null)
            {
                return null;
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> Actualizar(int id, UsuarioUpdateReq request)
        {
            Usuario? usuario = await _context.Usuarios
            .Include(a => a.Persona)
            .FirstOrDefaultAsync(a => a.Id == id);
            _mapper.Map(request,usuario); 
            _mapper.Map(request,usuario.Persona); 
            await _context.SaveChangesAsync();
            return usuario;
        }
 
        public async Task<List<UsuarioListaRes>?> Listar()
        {
            List<UsuarioListaRes>? response = await _context.Usuarios
            .Where(a => a.TipoId != 1)
            .Include(a => a.Tipo)
            .Include(a => a.Persona.Sede)
            .Select(a => new UsuarioListaRes
            {
                Id = a.Id,
                Contrasena = a.Contrasena,                
                HorarioEntrada = a.HorarioEntrada,
                HorarioAlmuerzo = a.HorarioAlmuerzo,
                HorarioRegreso = a.HorarioRegreso,
                HorarioSalida = a.HorarioSalida,
                Cmp = a.Cmp,
                TipoUsuario = a.Tipo.Nombre,
                PersonaI = new PersonaListaRes
                {
                    Id = a.Persona.Id,
                    NombreCompleto = $"{a.Persona.Nombres} {a.Persona.ApellidoPaterno} {a.Persona.ApellidoMaterno}",
                    Nombres = a.Persona.Nombres,
                    ApellidoPaterno = a.Persona.ApellidoPaterno,
                    ApellidoMaterno = a.Persona.ApellidoMaterno,
                    FechaNacimiento = a.Persona.FechaNacimiento,
                    Dni = a.Persona.Dni,
                    Sede = a.Persona.Sede.Nombre,
                    Telefono = a.Persona.Telefono,
                }
            })
            .ToListAsync();
            return response;
        }
    }
}