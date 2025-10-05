using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proy_back_QBD.Dto.Productos;

namespace Proy_back_QBD.Services.Interfaces
{
    public interface ILaboratorioService
    {
        Task<List<PedidoLab>> ListaLab(int pageNumber = 1, int pageSize = 30);
    }
}