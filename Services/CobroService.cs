using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;
using Proy_back_QBD.Response.Proy_back_QBD.Dto.Response;

namespace Proy_back_QBD.Services
{
    public class CobroService : ICobroService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public CobroService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CobroCreateRes?> Actualizar(int id, CobroUpdateReq request)
        {
            CobroCreateRes cobroCreateRes = new CobroCreateRes();

            Cobro? cobro = await _context.Cobros
            .FindAsync(id);

            if (cobro == null)
            {
                return null;
            }
            Pedido? pedido = await _context.Pedidos
                            .Include(i => i.Formulas)
                            .Include(i => i.ProdTerms)
                            .Include(i => i.Cobros)
                            .FirstOrDefaultAsync(fod => fod.Id == request.PedidoId);

            decimal? totalPedido = 0;
            decimal? totalCobro = 0;

            if (pedido.Formulas != null)
            {
                totalPedido = PedidoService.SumaPedido(pedido.Formulas, pedido.ProdTerms);
            }
            if (pedido.Cobros != null)
            {
                totalCobro = PedidoService.SumaCobro(pedido.Cobros);
            }

            if (totalCobro + request.Importe - cobro.Importe >= totalPedido)
            {
                cobroCreateRes.Msg = "Se ha superado el monto";
                return cobroCreateRes;
            }
            
            _mapper.Map(request, cobro);
            pedido.Adelanto = totalCobro;
            pedido.Saldo = totalPedido - totalCobro;
            await _context.SaveChangesAsync();
            cobroCreateRes.Cobro = cobro;
            return cobroCreateRes;
        }

        public async Task<CobroCreateRes?> Crear(CobroCreateReq request)
        {
            if (request.Importe == 0)
            {
                return null;
            }
            CobroCreateRes cobroCreateRes = new CobroCreateRes();
            Pedido? pedido = await _context.Pedidos
            .Include(i => i.Formulas)
            .Include(i => i.ProdTerms)
            .Include(i => i.Cobros)
            .FirstOrDefaultAsync(fod => fod.Id == request.PedidoId);
            
            if (pedido == null)
            {
                return null;
            }

            decimal? totalPedido = 0;
            decimal? totalCobro = 0;

            if (pedido.Formulas != null)
            {
                totalPedido = PedidoService.SumaPedido(pedido.Formulas, pedido.ProdTerms);
            }
            if (pedido.Cobros != null)
            {
                totalCobro = PedidoService.SumaCobro(pedido.Cobros);
            }

            if (totalCobro + request.Importe > totalPedido)
            {
                cobroCreateRes.Msg = "Se ha superado el monto";
                return cobroCreateRes;
            }

            Cobro cobro = _mapper.Map<Cobro>(request);
            cobro.ModificadorId = cobro.CreadorId;
            await _context.Cobros.AddAsync(cobro);
            pedido.Adelanto = totalCobro+cobro.Importe;
            pedido.Saldo = totalPedido - (totalCobro + cobro.Importe);
            await _context.SaveChangesAsync();
            cobroCreateRes.Cobro = cobro;
            return cobroCreateRes;

        }

        // public async Task<List<CobroFindAllResponse?>> Obtener()
        // {
        //     List<CobroFindAllResponse>? response = await _context.Cobros
        //     .Include(a => a.Paciente.Persona)
        //     .Include(a => a.Medico.Persona)
        //     .Include(a => a.Creador)
        //     .Include(a => a.Cobros)
        //     .Include(a => a.Formulas)
        //     .Include(a => a.ProdTerms)
        //     .Select(a => new CobroFindAllResponse
        //     {
        //         Id = a.Id,
        //         Cuo = $"BDRP-{a.Id}",
        //         FechaCreacion = a.FechaCreacion,
        //         Dni = a.Paciente.Persona.Dni,
        //         Paciente = $"{a.Paciente.Persona.Nombres} {a.Paciente.Persona.Apellidos}",
        //         Celular = a.Paciente.Persona.Telefono,
        //         Medico = $"Dr. {a.Medico.Persona.Apellidos}",
        //         Total = SumaCobro(a.Formulas, a.ProdTerms),
        //         Adelanto = SumaCobro(a.Cobros),
        //         Saldo = SumaCobro(a.Formulas, a.ProdTerms) - SumaCobro(a.Cobros),
        //         Recibo = a.Boleta,
        //         Estado = CalcularEstado(a.Formulas),
        //         FechaEntrega = a.FechaEntrega,
        //         Usuario = a.Creador.Codigo,
        //         BolFaC = a.ComprobanteElectronico,
        //     })
        //     .ToListAsync();

        //     if (response == null)
        //     {
        //         return null;
        //     }
        //     return response;
        // }
    }

}
