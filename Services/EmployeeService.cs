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
    public class EmployeeService : IEmployeeService
    {
        private readonly AuthService _authService;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(ApiContext context, AuthService authService, IMapper mapper)
        {
            _context = context;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<EmployeeFilledRes?> AutoFilledService(string codigo, string tipoAsistencia)
        {
            var response = await _context.Employees
            .Where(u => u.Codigo.Equals(codigo))
            .Select(a => new EmployeeFilledRes
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

        public async Task<int?> Actualizar(int id, EmployeeUpdateReq request)
        {
            Employee? employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            employee.DNI = request.DNI;
            employee.CMP = request.CMP;
            employee.Nombres= request.Nombres;
            employee.ApellidoPaterno = request.ApellidoPaterno;
            employee.ApellidoMaterno = request.ApellidoMaterno;
            employee.Contrasena = _authService.HashPassword(request.Contrasena);
            employee.IdTipo = request.IdTipo;
            employee.IdCreador = request.IdCreador;
            employee.IdSede = request.IdSede;
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<int?> CreateEmployeeService(Employee request)
        {
            if (request == null)
            {
                return null;
            }
            request.Contrasena = _authService.HashPassword(request.Contrasena);
            _context.Employees.AddAsync(request);
            await _context.SaveChangesAsync();
            return request.Id;
        }
    }
}