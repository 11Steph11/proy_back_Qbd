using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IEmployeeService
    {
        Task<int?> RegistrarTrabajadorAsync(Employee trabajador);
        Task<Employee?> AutoFilled(string code);
    }
}