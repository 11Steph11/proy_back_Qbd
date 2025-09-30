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

            string? estado = PedidoService.CalcularEstado(pedido.Formulas);
            if (pedido.Estado != estado)
            {
                pedido.Estado = estado;
            }

            await _context.SaveChangesAsync();
            
            return response;
        }

        public async Task<FormulaCreateResponse?> Crear(FormulaCreateReq request)
        {
            FormulaCreateResponse response = new FormulaCreateResponse();


            Formula formula = _mapper.Map<Formula>(request);
            formula.ModificadorId = formula.CreadorId;
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

            string? estado = PedidoService.CalcularEstado(pedido.Formulas);
            if (pedido.Estado != estado)
            {
                pedido.Estado = estado;
            }
            pedido.Total = pedido.Total + formula.Costo;

            return response;
        }

        public async Task<Formula?> Eliminar(int id)
        {
            Formula? formula = await _context.Formulas
           .FindAsync(id);
            _context.Formulas.Remove(formula);
            await _context.SaveChangesAsync();
            return formula;
        }

    }
}