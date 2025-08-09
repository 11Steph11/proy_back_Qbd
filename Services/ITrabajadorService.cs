using Proy_back_QBD.Dto;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface ITrabajadorService
    {
        Task<int?> Crear(Trabajador trabajador);
        Task<int?> Actualizar(int id, TrabajadorUpdateReq request);
        Task<int?> Eliminar(int id);
        Task<TrabListarRes?> Listar();
        Task<TrabRellenarByCodRes?> Rellenar(string codigo, string tipoAsistencia);
        Task<TrabRellenarByIdRes?> Rellenar(int id);
    }
}