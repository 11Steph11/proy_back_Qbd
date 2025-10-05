using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class ProdTermService : IProdTermService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ProdTermService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProdTerm?> Actualizar(int id, ProdTermUpdateReq request)
        {
            ProdTerm? prodTerm = await _context.ProdTerms
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
            if (prodTerm == null)
            {
                return null;
            }

            _mapper.Map(request, prodTerm);

            await _context.SaveChangesAsync();

            Pedido? pedido = await _context.Pedidos
            .Include(i => i.ProdTerms)
            .FirstOrDefaultAsync(fod => fod.Id == prodTerm.Id);
            
            if (pedido == null)
            {
                return null;
            }
            List<ProdTerm>? prodTerms = pedido.ProdTerms;
            if (prodTerms == null)
            {
                return null;
            }

            decimal costoReq = 0;
            costoReq = request.Costo * request.Cantidad;
            decimal costoForm = 0;
            costoForm = prodTerm.Costo * prodTerm.Cantidad;
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

            return prodTerm;
        }

        public async Task<ProdTerm?> Crear(ProdTermCreateReq request)
        {
            ProdTerm prodTerm = _mapper.Map<ProdTerm>(request);
            prodTerm.ModificadorId = prodTerm.CreadorId;
            prodTerm.Estado = "TERMINADO";

            await _context.ProdTerms.AddAsync(prodTerm);
            await _context.SaveChangesAsync();

            Pedido? pedido = await _context.Pedidos
            .Include(i => i.ProdTerms)
            .FirstOrDefaultAsync(fod => fod.Id == request.PedidoId);

            if (pedido == null)
            {
                return null;
            }

            pedido.Total += prodTerm.Costo * prodTerm.Cantidad;
            pedido.Saldo += prodTerm.Costo * prodTerm.Cantidad;

            return prodTerm;
        }

        public async Task<ProdTerm?> Eliminar(int id)
        {
            ProdTerm? prodTerm = await _context.ProdTerms
           .FirstOrDefaultAsync(a => a.Id == id);
            if (prodTerm == null)
            {
                return null;
            }
            _context.ProdTerms.Remove(prodTerm);
            await _context.SaveChangesAsync();

            Pedido? pedido = await _context.Pedidos
                        .Include(i => i.ProdTerms)
                        .FirstOrDefaultAsync(fod => fod.Id == prodTerm.PedidoId);
            if (pedido == null)
            {
                return null;
            }

            pedido.Total -= prodTerm.Costo * prodTerm.Cantidad;
            pedido.Saldo -= prodTerm.Costo * prodTerm.Cantidad;

            return prodTerm;
        }

    }
}