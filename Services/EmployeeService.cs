using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Proy_back_QBD.Dto.Response;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Dto;

namespace Proy_back_QBD.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AuthService _authService;
        private readonly ApiContext _context;
        public EmployeeService(ApiContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<EmployeeFilledRes?> AutoFilled(EmployeeFilledReq request)
        {
            if (request == null)
            {
                return null;
            }
            var response = await _context.Employees
            .Where(u => u.Codigo.Equals(request.Codigo))
            .Select(a => new EmployeeFilledRes
            {
                Dni = a.DNI,
                NombreCompleto = $"{a.Nombres} {a.ApellidoPaterno} {a.ApellidoMaterno}",
                HoraAsignada = request.TipoAsistencia == "ALMUERZO" ? a.HoraAlmuerzo :
                request.TipoAsistencia == "REGRESO" ? a.HoraRegreso :
                request.TipoAsistencia == "SALIDA" ? a.HoraSalida :
                request.TipoAsistencia == "ENTRADA" ? a.HoraEntrada : null
            })
            .FirstOrDefaultAsync();
            return response;
        }

        public async Task<int?> RegistrarTrabajadorAsync(Employee trabajador)
        {
            if (trabajador == null)
            {
                return null;
            }
            trabajador.Contrasena = _authService.HashPassword(trabajador.Contrasena);
            _context.Employees.AddAsync(trabajador);
            await _context.SaveChangesAsync();
            return trabajador.Id;
        }
    }
}