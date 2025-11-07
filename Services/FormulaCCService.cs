using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class FormulaCCService : IFormulaCCService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public FormulaCCService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FormulaCC>>? Actualizar(int formulaId, List<FormulaCCUpdReq> request)
        {
            List<FormulaCC>? formulasCC = await _context.FormulasCC
            .Where(w => w.FormulaId == formulaId)
            .ToListAsync();
            if (formulasCC == null)
            {
                return null;
            }
            IEnumerable<int> InsumosReq = request.Select(s => s.InsumoId);
            IEnumerable<int> InsumosFormulas = formulasCC.Select(s => s.InsumoId);
            List<FormulaCC>? auxiliar = new();
            foreach (var formula in request)
            {
                if (!InsumosFormulas.Contains(formula.InsumoId))
                {
                    FormulaCC formulaM = _mapper.Map<FormulaCC>(formula);
                    formulaM.FormulaId = formulaId;
                    _context.FormulasCC.Add(formulaM);
                    auxiliar.Add(formulaM);
                }
                foreach (var formula2 in formulasCC)
                {
                    if (formula2.InsumoId == formula.InsumoId)
                    {

                        _mapper.Map(formula, formula2);
                        auxiliar.Add(formula2);
                    }
                    if (!InsumosReq.Contains(formula2.InsumoId))
                    {
                        _context.FormulasCC.Remove(formula2);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return auxiliar;
        }

        public async Task<List<RecetaRes>?> ListarInsumos(int sedeId)
        {
            List<RecetaRes> response = await _context.FormulasCC
            .Select(s => new RecetaRes
            {

            })
            .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return response;
        }

        public async Task<FormulaCCLabRes>? ListarInsumosLab(int formulaId)
        {
            FormulaCCLabRes? response = await _context.FormulasCC
            .Include(i => i.Formula.Pedido.Paciente.Persona)
            .Include(i => i.Formula.Pedido.Medico.Persona)
            .Include(i => i.Formula.Laboratorio)
            .Include(i => i.Insumo)
            .Where(w => w.FormulaId == formulaId)
            .Select(s => new FormulaCCLabRes
            {
                CodigoPedido = "P-" + s.Formula.PedidoId,
                DniPaciente = s.Formula.Pedido.Paciente.Persona.Dni ?? s.Formula.Pedido.Paciente.DniApoderado,
                NombreCompleto = s.Formula.Pedido.Paciente.Persona.NombreCompleto,
                EdadPaciente = PacienteService.CalcularEdad(s.Formula.Pedido.Paciente.Persona.FechaNacimiento),
                CMP = s.Formula.Pedido.Medico.Cmp,
                NombreCompletoMed = s.Formula.Pedido.Medico.Persona.NombreCompleto,
                FormulaMagistral = s.Formula.FormulaMagistral,
                Lote = s.Formula.Lote,
                NroReg = "REG-" + s.Formula.Id,
                Cantidad = s.Formula.Cantidad,
                GPorMl = s.Formula.GPorMl,
                UnidadMedida = s.Formula.UnidadMedida,
                CostoTotal = s.Formula.Costo,
                EmpaqueId = s.Formula.Laboratorio.EmpaqueId,

            })
            .FirstOrDefaultAsync();
            if (response == null)
            {
                return null;
            }
            List<FormulaCCLabSubRes>? response2 = await _context.FormulasCC
            .Include(i => i.Insumo)
            .Where(w => w.FormulaId == formulaId)
            .OrderBy(ob => ob.Variable)
            .Select(s => new FormulaCCLabSubRes
            {
                InsumoId = s.InsumoId,
                Porcentaje = s.Porcentaje.ToString(),
                Variable = s.Variable,
                Practica = s.Practica.ToString(),
                CSP = s.CSP
            }).ToListAsync();

            if (response2 == null)
            {
                return null;
            }
            response.insumos = response2;
            return response;
        }
    }
}