using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public PedidoService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PedidoUpdateResponse?> Actualizar(int id, PedidoUpdateReq request)
        {
            PedidoUpdateResponse response = new PedidoUpdateResponse();
            Pedido? pedido = await _context.Pedidos
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
            if (pedido == null)
            {
                response.Msg = "no se encontró";
                return response;
            }
            _mapper.Map(request, pedido);          
            response.Msg = "Pedido Actualizado";
            response.PedidoRes = pedido;
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<PedidoCreateResponse?> Crear(PedidoCreateReq request)
        {
            PedidoCreateResponse response = new PedidoCreateResponse();
            Pedido pedido = _mapper.Map<Pedido>(request);
            pedido.ModificadorId = pedido.CreadorId;
            response.PedidoRes = pedido;
            response.Msg = "Pedido creado exitosamente.";
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();

            foreach (var item in request.ProductosTerminados)
            {
                ProdTerm prodTerm = _mapper.Map<ProdTerm>(item);
                prodTerm.ModificadorId = prodTerm.CreadorId;
                prodTerm.PedidoId = pedido.Id;
                await _context.AddAsync(prodTerm);
            }

            foreach (var item in request.Formulas)
            {
                Formula formula = _mapper.Map<Formula>(item);
                formula.ModificadorId = formula.CreadorId;
                formula.PedidoId = pedido.Id;
                await _context.AddAsync(formula);
            }
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<Pedido?> Eliminar(int id)
        {
            Pedido? pedido = await _context.Pedidos
            .Include(p => p.Formulas)
            .Include(p => p.ProdTerms)
           .FirstOrDefaultAsync(a => a.Id == id);
            _context.Pedidos.Remove(pedido);
            foreach (var formulaFor in pedido.Formulas)
            {
                Formula formula = _mapper.Map<Formula>(formulaFor);
                _context.Formulas.Remove(formula);
            }
            foreach (var prodTermFor in pedido.ProdTerms)
            {
                ProdTerm prodTerm = _mapper.Map<ProdTerm>(prodTermFor);
                _context.ProductoTerminados.Remove(prodTerm);
            }
            await _context.SaveChangesAsync();
            return pedido;
        }

        // public async Task<List<PedidoFindAllResponse?>> Obtener()
        // {
        //     List<PedidoFindAllResponse>? response = await _context.Pedidos
        //     .Include(a => a.PersonaFk)
        //     .Select(a => new PedidoFindAllResponse
        //     {
        //         Id = a.Id,
        //         NombreCompleto = $"{a.PersonaFk.Nombres} {a.PersonaFk.Apellidos}",
        //         Apoderado = a.Apoderado,
        //         DniApoderado = a.DniApoderado,
        //     })
        //     .ToListAsync();

        //     if (response == null)
        //     {
        //         return null;
        //     }
        //     return response;
        // }

        // public async Task<PedidoFindIdResponse?> ObtenerById(int id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}