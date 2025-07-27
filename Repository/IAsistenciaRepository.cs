using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Response;

namespace Proy_back_QBD.Repository
{
    public interface IAsistenciaRepository
    {
        Task<AsistenciaCreateResponse?> RegistrarAsync(Asistencia asistencia);
    }
}
