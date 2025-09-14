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

        public async Task<List<PedidoFindAllResponse?>> Obtener()
        {
            List<PedidoFindAllResponse>? response = await _context.Pedidos
            .Include(a => a.Paciente.Persona)
            .Include(a => a.Medico.Persona)
            .Include(a => a.Creador)
            .Include(a => a.Cobros)
            .Include(a => a.Formulas)
            .Include(a => a.ProdTerms)
            .Select(a => new PedidoFindAllResponse
            {
                Id = a.Id,
                Cuo = $"BDRP-{a.Id}",
                FechaCreacion = a.FechaCreacion,
                Dni = a.Paciente.Persona.Dni,
                Paciente = $"{a.Paciente.Persona.Nombres} {a.Paciente.Persona.Apellidos}",
                Celular = a.Paciente.Persona.Telefono,
                Medico = $"Dr. {a.Medico.Persona.Apellidos}",
                Total = SumaPedido(a.Formulas, a.ProdTerms),
                Adelanto = SumaCobro(a.Cobros),
                Saldo = SumaPedido(a.Formulas, a.ProdTerms) - SumaCobro(a.Cobros),
                Recibo = a.Boleta,
                Estado = CalcularEstado(a.Formulas),
                FechaEntrega = a.FechaEntrega,
                Usuario = a.Creador.Codigo,
                BolFaC = a.ComprobanteElectronico,
            })
            .ToListAsync();

            if (response == null)
            {
                return null;
            }
            return response;
        }
        public static string? CalcularEstado(List<Formula> Formulas)
        {
            string? resultado = "ENTREGADO";
            foreach (var formula in Formulas)
            {
                if (formula.Estado.Trim().ToUpper().Equals("PENDIENTE"))
                {
                    resultado = "PENDIENTE";
                }
                else if (formula.Estado.Trim().ToUpper().Equals("EN PROCESO"))
                {
                    resultado = "EN PROCESO";
                }
                else if (formula.Estado.Trim().ToUpper().Equals("ENTREGADOS"))
                {
                    resultado = "ENTREGADOS";
                }
            }
            return resultado;

        }
        public async Task<PedidoFindIdResponse?> ObtenerById(int id)
        {
            throw new NotImplementedException();
        }
        public static decimal? SumaPedido(List<Formula> listaForm, List<ProdTerm> listaProdTerm)
        {
            decimal? total = 0;
            foreach (var formula in listaForm)
            {
                total += formula.Costo;
            }
            foreach (var prod in listaProdTerm)
            {
                total += prod.Costo;
            }
            return total;
        }
        public static decimal? SumaCobro(List<Cobro> listaCobro)
        {
            decimal? total = 0;
            foreach (var cobro in listaCobro)
            {
                total += cobro.Importe;
            }
            return total;
        }

    }
}