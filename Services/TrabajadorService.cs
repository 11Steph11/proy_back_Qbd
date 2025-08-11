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

        public async Task<TrabajadorRellenarByCodAsistRes?> Rellenar(string codigo, string tipoAsistencia)
        {
            var response = await _context.Trabajadores
            .Where(u => u.Codigo.Equals(codigo))
            .Select(a => new TrabajadorRellenarByCodAsistRes
            {
                Dni = a.CMP,
                NombreCompleto = a.Datos,
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

        public async Task<TrabRellenarByCodGestRes?> Rellenar(string codigo)
        {
            TrabRellenarByCodGestRes? response = await _context.Trabajadores
            .Where(u => u.Codigo.Equals(codigo))
            .Select(a => new TrabRellenarByCodGestRes
            {
                Codigo = a.Codigo,
                DniCmp = a.CMP,
                Datos = a.Datos,
                HoraEntrada = a.HoraEntrada,
                HoraAlmuerzo = a.HoraAlmuerzo,
                HoraRegreso = a.HoraRegreso,
                HoraSalida = a.HoraSalida,
                IdSede = a.IdSede,
            })
            .FirstOrDefaultAsync();

            if (response == null)
            {
                return null;
            }
            
            return response;
        }

        public async Task<string?> Actualizar(string codigo, TrabajadorUpdateReq request)
        {
            Trabajadores? trabajador = await _context.Trabajadores.FindAsync(codigo);
            if (trabajador == null)
            {
                return null;
            }
            trabajador.Codigo = request.Codigo;
            trabajador.CMP = request.DNICMP;
            trabajador.Datos = request.Datos;
            trabajador.HoraEntrada = request.HoraEntrada;
            trabajador.HoraAlmuerzo = request.HoraAlmuerzo;
            trabajador.HoraRegreso = request.HoraRegreso;
            trabajador.HoraSalida = request.HoraSalida;
            trabajador.IdSede = request.IdSede;
            await _context.SaveChangesAsync();
            return trabajador.Codigo;
        }

        public async Task<string?> Crear(TrabajadorCreateReq request)
        {
            Trabajadores? trabajador = _mapper.Map<Trabajadores>(request);
            await _context.Trabajadores.AddAsync(trabajador);
            await _context.SaveChangesAsync();
            return request.Codigo;
        }

        public async Task<string?> Eliminar(string codigo)
        {
            Trabajadores? employee = await _context.Trabajadores.FindAsync(codigo);
            if (employee == null)
            {
                return null;
            }
            _context.Trabajadores.Remove(employee);
            await _context.SaveChangesAsync();
            return codigo;
        }
        public async Task<TrabajadorListarRes> Listar()
        {
            List<ListaTrabajadores> listEmployee = await _context.Trabajadores
            .Select(a => new ListaTrabajadores()
            {
                Codigo = a.Codigo,
                Descripcion = a.Datos
            })
            .ToListAsync();
            if (listEmployee == null)
            {
                return null;
            }
            TrabajadorListarRes response = new TrabajadorListarRes
            {
                Total = listEmployee.Count(),
                ListaTrabajadores = listEmployee
            };
            return response;
        }

    }
}