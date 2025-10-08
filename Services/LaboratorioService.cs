using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Productos;
using Proy_back_QBD.Models;
using Proy_back_QBD.Services.Interfaces;

namespace Proy_back_QBD.Services
{
    public class LaboratorioService : ILaboratorioService
    {
        private readonly ApiContext _db;
        private readonly IMapper _Mappers;
        public LaboratorioService(ApiContext db, IMapper Mappers)
        {
            _db = db;
            _Mappers = Mappers;
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

        public async Task<LabFindPedIdRes?> ObtenerByCod(string cod)
        {
            int id = 0;
            var partes = cod.Split('-');
            if (partes.Length == 2 && int.TryParse(partes[1], out int numero))
            {
                id = numero;
            }

            LabFindPedIdRes? response = await _db.Pedidos
                                        .Include(i => i.Paciente.Persona)
                                        .Include(i => i.Medico.Persona)
                                        .Where(w => w.Id == id)
                                        .Select(s => new LabFindPedIdRes
                                        {
                                            DNI = s.Paciente.Persona.Dni ?? s.Paciente.DniApoderado,
                                            Paciente = s.Paciente.Persona.NombreCompleto,
                                            Edad = PacienteService.CalcularEdad(s.Paciente.Persona.FechaNacimiento),
                                            CMP = s.Medico.Cmp,
                                            Medico = s.Medico.Persona.NombreCompleto,
                                            Formulas = s.Formulas.Select(f => new LabForm
                                            {
                                                Id = f.Id,
                                                FormulaF = f.FormulaFarmaceutica,
                                                Lote = f.Lote,
                                                Registro = "REG-" + f.Id,
                                                Diagnostico = f.Diagnostico,
                                                ZonaAplicacion = f.ZonaAplicacion,
                                                CostoTotal = f.Cantidad * f.Costo,

                                            }).ToList()
                                        }
                                        )
                                        .FirstOrDefaultAsync();

            if (response == null)
            {
                return null;
            }
            return response;
        }
        public async Task<string?> RegistrarLabIns(FormLabIns request)
        {

            string response;

            Laboratorio laboratorio = _Mappers.Map<Laboratorio>(request.Lab);
            laboratorio.ModificadorId =laboratorio.CreadorId;
            foreach (var item in request.Ins)
            {
                FormulaCC formulaCC = _Mappers.Map<FormulaCC>(item);
                formulaCC.ModificadorId = formulaCC.CreadorId;
                _db.FormulasCC.Add(formulaCC);
            }

            _db.Laboratorios.Add(laboratorio);

            await _db.SaveChangesAsync();

            response = "Registro exitoso";
            return response;

        }
    }
}