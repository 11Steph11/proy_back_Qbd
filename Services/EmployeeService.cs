using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Data;

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

        public Task<Employee?> AutoFilled(string code)
        {
            throw new NotImplementedException();
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