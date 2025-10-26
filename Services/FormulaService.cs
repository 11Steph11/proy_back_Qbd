using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class FormulaService : IFormulaService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public FormulaService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Formula> ActualizarFormulaM(int formulaId, string FormulaMagistral)
        {
            Formula? formula = await _context.Formulas.FindAsync(formulaId);
            if (formula == null)
            {
                return null;
            }
            formula.FormulaMagistral = FormulaMagistral;
            await _context.SaveChangesAsync();
            return formula;
        }
        public async Task<FormulaUpdateResponse?> Actualizar(int id, FormulaUpdateReq request)
        {
            FormulaUpdateResponse response = new FormulaUpdateResponse();

            Formula? formulaFind = await _context.Formulas
            .Include(i => i.Pedido.Formulas)
            .Include(i => i.Pedido.ProdTerms)
            .FirstOrDefaultAsync(f => f.Id == id);

            if (formulaFind == null)
            {
                response.Msg = "no se encontró";
                return response;
            }

            Pedido? pedido = formulaFind.Pedido;
            if (pedido == null)
            {
                return null;
            }
            List<Formula>? formulas = pedido?.Formulas;
            List<ProdTerm>? prodTerms = pedido?.ProdTerms;
            if (formulas == null && prodTerms == null)
            {
                return null;
            }
            decimal total = PedidoService.SumaPedido(formulas, prodTerms);
            total = total - (formulaFind.Cantidad * formulaFind.Costo) + (request.Cantidad * request.Costo);
            pedido.Total = total;
            pedido.Saldo = total - pedido.Adelanto;
            _mapper.Map(request, formulaFind);
            response.Msg = "Formula Actualizado";
            response.FormulaRes = formulaFind;

            await _context.SaveChangesAsync();

            // string? estado = PedidoService.CalcularEstado(formulas);
            // if (pedido.Estado != estado)
            // {
            //     pedido.Estado = estado;
            // }

            return response;
        }
        public async Task<string?> AgregarInjerto(int id, string injerto)
        {
            string Msg;
            Formula? formula = await _context.Formulas
            .FirstOrDefaultAsync(f => f.Id == id);
            if (formula == null)
            {
                return null;
            }
            formula.Injerto = injerto;
            await _context.SaveChangesAsync();
            Msg = "Se añadio correctamente";

            return Msg;
        }
        public async Task<FormulaCreateResponse?> CrearFormPed(FormulaCreateReq request)
        {
            FormulaCreateResponse response = new FormulaCreateResponse();
            DateOnly Hoy = DateOnly.FromDateTime(DateTime.Now);
            int correlativo = await _context.Formulas
                                    .Where(w => DateOnly.FromDateTime(w.FechaCreacion) == Hoy)
                                    .CountAsync() + 1;


            var codLote =
           DateTime.Now.Year.ToString().Substring(2, 2) +
           DateTime.Now.Month.ToString("D2") +
           DateTime.Now.Day.ToString("D2");

            Formula formula = _mapper.Map<Formula>(request);
            formula.ModificadorId = formula.CreadorId;
            formula.Estado = "PENDIENTE";
            formula.Lote = codLote + correlativo;
            response.FormulaRes = formula;
            response.Msg = "Formula creado exitosamente.";

            Pedido? pedido = await _context.Pedidos
            .Include(i => i.Formulas)
            .Include(i => i.ProdTerms)
            .Include(i => i.Cobros)
            .FirstOrDefaultAsync(fod => fod.Id == request.PedidoId);

            if (pedido == null)
            {
                return null;
            }

            pedido.Total = PedidoService.SumaPedido(pedido.Formulas, pedido.ProdTerms);
            pedido.Total += formula.Costo * formula.Cantidad;
            pedido.Saldo = pedido.Total - pedido.Adelanto;
            // Maneja un estado virtual no poner antes
            await _context.Formulas.AddAsync(formula);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<Formula?> Eliminar(int id)
        {
            Formula? formula = await _context.Formulas
           .FindAsync(id);
            _context.Formulas.Remove(formula);
            Pedido? pedido = await _context.Pedidos.FindAsync(formula.PedidoId);
            pedido.Total -= formula.Costo * formula.Cantidad;
            await _context.SaveChangesAsync();
            return formula;
        }

        public async Task<List<RecetaRes>?> ListarReceta(int sedeId)
        {
            List<RecetaRes> response = await _context.Formulas
            .Include(i => i.Pedido.Medico.Persona)
            .Include(i => i.Pedido.Paciente.Persona)
            .Select(s => new RecetaRes
            {
                Medico = s.Pedido.Medico.Persona.NombreCompleto,
                Fecha = DateOnly.FromDateTime(s.FechaCreacion),
                Prescripcion = s.FormulaMagistral,
                Gram = s.UnidadMedida == "G" ? s.GPorMl.ToString() : null,
                Cant = s.Cantidad,
                Mili = s.UnidadMedida == "ML" ? s.GPorMl.ToString() : null,
                Gotas = s.UnidadMedida == "Gotas" ? s.GPorMl.ToString() : null,
                Observacion = s.Pedido.Paciente.Persona.NombreCompleto,
                Precio = s.Costo,
                Tipo = s.Reportado
            })
            .ToListAsync();
            if (response == null)
            {
                return null;
            }

            return response;
        }
        public async Task<FormulasLab> ListarFormulasLab(int pedidoId)
        {
            try
            {
                FormulasLab? response = await _context.Pedidos
                .Include(i => i.Medico.Persona)
                .Include(i => i.Paciente.Persona)
                .Include(i => i.Formulas)
                .Where(w => w.Id == pedidoId)
                .Select(s => new FormulasLab
                {
                    Paciente = s.Paciente.Persona.NombreCompleto,
                    DNI = s.Paciente.Persona.Dni ?? s.Paciente.DniApoderado,
                    Edad = PacienteService.CalcularEdad(s.Paciente.Persona.FechaNacimiento),
                    Medico = s.Medico.Persona.NombreCompleto,
                    CMP = s.Medico.Cmp,
                    Formulas = s.Formulas.Select(s => new FormulasLab2
                    {
                        Costo = s.Costo,
                        Cantidad = s.Cantidad,
                        FormulaMagistral = s.FormulaMagistral,
                        GPorMl = s.GPorMl,
                        NReg = "REG-" + s.Id,
                        Lote = "FM" + s.Lote,
                        Diagnostico = s.Diagnostico,
                        Zona = s.ZonaAplicacion,
                    }).ToList()
                })
                .FirstOrDefaultAsync();
                response.Items = response.Formulas.Count;
                response.CantidadTotal = 0;
                response.CostoTotal = 0;
                foreach (var item in response.Formulas)
                {
                    response.CantidadTotal += item.Cantidad;
                    response.CostoTotal += item.Cantidad * item.Costo;
                }

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch (System.Exception)
            {

                throw;
            }


        }

        public async Task<Formula?> ActualizarLab(int formulaId, FormulaUpdLabReq request)
        {

            Formula? formula = await _context.Formulas
            .Include(i => i.Laboratorio)
            .FirstOrDefaultAsync(foda => foda.Id == formulaId);

            if (formula == null)
            {
                return null;
            }

            Laboratorio? laboratorio = formula?.Laboratorio;
            if (laboratorio == null)
            {
                return null;
            }

            formula.Costo = request.Costo;
            formula.Cantidad = request.Cantidad;
            formula.FormulaMagistral = request.FormulaMagistral;
            formula.FormaFarmaceutica = request.FormaFarmaceutica;
            formula.GPorMl = request.GPorMl;
            formula.UnidadMedida = request.UnidadMedida;
            formula.ModificadorId = request.ModificadorId;
            laboratorio.FechaEmision = request.FechaEmision;
            laboratorio.FechaVcto = request.FechaVencimiento;

            await _context.SaveChangesAsync();

            return formula;
        }

        public async Task<EtiquetaRes?> ObtenerEtiqueta(int formulaId)
        {
            EtiquetaRes res = await _context.Formulas
            .Include(i => i.Pedido.Paciente.Persona)
            .Include(i => i.Pedido.Medico.Persona)
            .Include(i => i.Laboratorio)
            .Where(w => w.Id == formulaId)
            .Select(s => new EtiquetaRes
            {
                NReg = "REG-" + s.Id,
                DNI = s.Pedido.Paciente.Persona.Dni ?? s.Pedido.Paciente.DniApoderado,
                Paciente = s.Pedido.Paciente.Persona.NombreCompleto,
                FormulaMagistral = s.FormulaMagistral,
                FechaEmision = s.Laboratorio.FechaEmision + "",
                FechaVencimiento = s.Laboratorio.FechaVcto + "",
                CMP = s.Pedido.Medico.Cmp,
                Medico = s.Pedido.Medico.Persona.NombreCompleto
            }
            )
            .FirstOrDefaultAsync();

            return res;
        }
    }
}