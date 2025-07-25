using Proy_back_QBD.Models;

namespace Proy_back_QBD.Services
{
    public interface ITrabajadorService
    {
        Task<int?> RegistrarTrabajadorAsync(Trabajador trabajador);
    }
}