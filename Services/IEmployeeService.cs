using Proy_back_QBD.Dto;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IEmployeeService
    {
        Task<int?> RegistrarTrabajadorAsync(Employee trabajador);
        Task<EmployeeFilledRes?> AutoFilled(EmployeeFilledReq code);
    }
}