using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Proy_back_QBD.Dto.Response;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Dto;
using AutoMapper;
using Proy_back_QBD.Dto.Request;

namespace Proy_back_QBD.Services
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly AuthService _authService;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public TrabajadorService(ApiContext context, AuthService authService, IMapper mapper)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<TrabRellenarByCodRes?> Rellenar(string codigo, string tipoAsistencia)
        {
            var response = await _context.Trabajador
            .Where(u => u.Codigo.Equals(codigo))
            .Select(a => new TrabRellenarByCodRes
            {
                Dni = a.DNI,
                NombreCompleto = $"{a.Nombres} {a.ApellidoPaterno} {a.ApellidoMaterno}",
                HoraAsignada = tipoAsistencia == "ALMUERZO" ? a.HoraAlmuerzo :
                tipoAsistencia == "REGRESO" ? a.HoraRegreso :
                tipoAsistencia == "SALIDA" ? a.HoraSalida :
                tipoAsistencia == "ENTRADA" ? a.HoraEntrada : null
            })
            .FirstOrDefaultAsync();
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public async Task<TrabRellenarByIdRes?> Rellenar(int id)
        {
            TrabRellenarByIdRes? response = await _context.Trabajador
            .Where(u => u.Id == id)
            .Select(a => new TrabRellenarByIdRes
            {
                Codigo = a.Codigo,
                Dni = a.DNI,
                Cmp = a.CMP,
                Nombres = a.Nombres,
                ApellidoPaterno = a.ApellidoPaterno,
                ApellidoMaterno = a.ApellidoMaterno,
                HoraEntrada = a.HoraEntrada,
                HoraAlmuerzo = a.HoraAlmuerzo,
                HoraRegreso = a.HoraRegreso,
                HoraSalida = a.HoraSalida,
                IdSede = a.IdSede,
                Contrasena = a.Contrasena
            })
            .FirstOrDefaultAsync();

            if (response == null)
            {
                return null;
            }
            
            return response;
        }

        public async Task<int?> Actualizar(int id, TrabajadorUpdateReq request)
        {
            Trabajador? employee = await _context.Trabajador.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            employee.DNI = request.DNI;
            employee.CMP = request.CMP;
            employee.Nombres = request.Nombres;
            employee.ApellidoPaterno = request.ApellidoPaterno;
            employee.ApellidoMaterno = request.ApellidoMaterno;
            employee.Contrasena = _authService.HashPassword(request.Contrasena);
            employee.IdTipo = request.IdTipo;
            employee.IdCreador = request.IdCreador;
            employee.IdSede = request.IdSede;
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<int?> Crear(Trabajador request)
        {
            request.Contrasena = _authService.HashPassword(request.Contrasena);
            await _context.Trabajador.AddAsync(request);
            await _context.SaveChangesAsync();
            return request.Id;
        }

        public async Task<int?> Eliminar(int id)
        {
            Trabajador? employee = await _context.Trabajador.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            _context.Trabajador.Remove(employee);
            await _context.SaveChangesAsync();
            return id;
        }
        public async Task<TrabListarRes> Listar()
        {
            List<ListaTrabajadores> listEmployee = await _context.Trabajador
            .Select(a => new ListaTrabajadores()
            {
                Codigo = a.Codigo,
                Id = a.Id,
                Descripcion = $"{a.Nombres} {a.ApellidoPaterno} {a.ApellidoMaterno}"
            })
            .ToListAsync();
            if (listEmployee == null)
            {
                return null;
            }
            TrabListarRes response = new TrabListarRes
            {
                Total = listEmployee.Count(),
                ListaTrabajadores = listEmployee
            };
            return response;
        }

    }
}