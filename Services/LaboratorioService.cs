using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Productos;
using Proy_back_QBD.Services.Interfaces;

namespace Proy_back_QBD.Services
{
    public class LaboratorioService : ILaboratorioService
    {
        private readonly ApiContext _db;
        public LaboratorioService(ApiContext db)
        {
            _db = db;
        }



        public async Task<List<PedidoLab>> ListaLab(int pageNumber = 1, int pageSize = 30)
        {
            var skipCount = (pageNumber - 1) * pageSize;  // Número de elementos a omitir

            var pedidosLab = await _db.Laboratorios
                                        .Include(i => i.Formula.Pedido.Paciente.Persona)
                                        .Skip(skipCount) // Omitir los registros de las páginas anteriores
                                        .Take(pageSize)  // Limitar a los primeros "pageSize" registros
                                        .Select(s => new PedidoLab
                                        {
                                            Cuo = "BDRP-" + s.Id,
                                            Fecha = s.FechaCreacion,
                                            DNI = s.Formula.Pedido.Paciente.Persona.Dni ?? s.Formula.Pedido.Paciente.DniApoderado,
                                            Paciente = s.Formula.Pedido.Paciente.Persona.NombreCompleto,
                                            FormulaMagistral = s.Formula.FormulaMagistral,
                                            Registro = "REG-" + s.Id,
                                            Elaborado = s.Elaborado,
                                        })
                                        .ToListAsync();

            return pedidosLab;
        }

    }
}