using Proy_back_QBD.Dto;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface IEmployeeService
    {
        Task<int?> CreateEmployeeService(Employee trabajador);
        Task<int?> Actualizar(int id, EmployeeUpdateReq request);
        Task<EmployeeFilledRes?> AutoFilledService(string codigo, string tipoAsistencia);
    }
}