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

        public async Task<FormulaUpdateResponse?> Actualizar(int id, FormulaUpdateReq request)
        {
            FormulaUpdateResponse response = new FormulaUpdateResponse();

            Formula? formula = await _context.Formulas
            .FirstOrDefaultAsync(f => f.Id == id);
            if (formula == null)
            {
                response.Msg = "no se encontró";
                return response;
            }

            _mapper.Map(request, formula);
            response.Msg = "Formula Actualizado";
            response.FormulaRes = formula;

            await _context.SaveChangesAsync();

            Pedido? pedido = await _context.Pedidos
            .Include(i => i.Formulas)
            .FirstOrDefaultAsync(fod => fod.Id == formula.Id);
            if (pedido == null)
            {
                return null;
            }
            List<Formula>? formulas = pedido.Formulas;
            if (formulas == null)
            {
                return null;
            }

            // string? estado = PedidoService.CalcularEstado(formulas);
            // if (pedido.Estado != estado)
            // {
            //     pedido.Estado = estado;
            // }

            decimal costoReq = 0;
            costoReq = request.Costo * request.Cantidad;
            decimal costoForm = 0;
            costoForm = formula.Costo * formula.Cantidad;
            decimal diferencia = Math.Abs(costoReq - costoForm);

            if (costoReq != costoForm)
            {
                if (costoReq > costoForm)
                {
                    pedido.Total -= diferencia;
                    pedido.Saldo -= diferencia;
                }
                else if (costoReq < costoForm)
                {
                    pedido.Total += diferencia;
                    pedido.Saldo += diferencia;
                }
            }

            await _context.SaveChangesAsync();

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
            formula.Lote = codLote + correlativo.ToString("D3");
            response.FormulaRes = formula;
            response.Msg = "Formula creado exitosamente.";

            await _context.Formulas.AddAsync(formula);
            await _context.SaveChangesAsync();

            Pedido? pedido = await _context.Pedidos
            .Include(i => i.Formulas)
            .FirstOrDefaultAsync(fod => fod.Id == request.PedidoId);

            if (pedido == null)
            {
                return null;
            }

            // string? estado = PedidoService.CalcularEstado(pedido.Formulas);
            // if (pedido.Estado != estado)
            // {
            //     pedido.Estado = estado;
            // }
            pedido.Total += formula.Costo * formula.Cantidad;
            pedido.Saldo += formula.Costo * formula.Cantidad;

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
    }
}