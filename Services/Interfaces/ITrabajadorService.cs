using Proy_back_QBD.Dto;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface ITrabajadorService
    {
        Task<string?> Crear(TrabajadorCreateReq trabajador);
        Task<string?> Actualizar(string id, TrabajadorUpdateReq request);
        Task<string?> Eliminar(string id);
        Task<TrabajadorListarRes?> Listar();
        Task<TrabajadorRellenarByCodAsistRes?> Rellenar(string codigo, string tipoAsistencia);
        Task<TrabRellenarByCodGestRes?> Rellenar(string codigo);
    }
}