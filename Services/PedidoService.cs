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
            List<Formula> formulaList = new();
            List<ProdTerm> prodTermList = new();

            foreach (var item in request.Formulas)
            {
                Formula formula = _mapper.Map<Formula>(item);
        
                formulaList.Add(formula);
            }
            foreach (var item in request.ProductosTerminados)
            {
                ProdTerm prodTerm = _mapper.Map<ProdTerm>(item);
        
                prodTermList.Add(prodTerm);
            }

            decimal? total = SumaPedido(formulaList, prodTermList);

            Pedido pedido = _mapper.Map<Pedido>(request);
            pedido.Total = total;
            pedido.Saldo = total;
            pedido.ModificadorId = pedido.CreadorId;
            response.PedidoRes = pedido;
            response.Msg = "Pedido creado exitosamente.";

            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();

            foreach (var item in prodTermList)
            {
                item.ModificadorId = item.CreadorId;
                item.PedidoId = pedido.Id;

                await _context.ProdTerms.AddAsync(item);
            }

            foreach (var item in formulaList)
            {
                item.ModificadorId = item.CreadorId;
                item.PedidoId = pedido.Id;

                await _context.Formulas.AddAsync(item);
            }

            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<Pedido?> ActualizarPedido(int id, string boleta)
        {
            Pedido? pedido = await _context.Pedidos
            .Include(p => p.Formulas)
            .Include(p => p.ProdTerms)
           .FirstOrDefaultAsync(a => a.Id == id);
            if (pedido == null) return null;

            pedido.Boleta = boleta;

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
                Paciente = $"{a.Paciente.Persona.NombreCompleto}",
                PacienteId = a.PacienteId,
                Celular = a.Paciente.Persona.Telefono,
                Medico = $"Dr. {a.Medico.Persona.NombreCompleto}",
                Total = a.Total,
                Adelanto = a.Adelanto,
                Saldo = a.Saldo,
                Recibo = a.Boleta,
                Estado = a.Estado,
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
                    resultado = "ENTREGADO";
                }
            }

            return resultado;
        }

        public async Task<PedidoFindIdResponse?> ObtenerById(int id)
        {
            Pedido? pedido = await _context.Pedidos
            .Include(a => a.Formulas)
            .Include(a => a.ProdTerms)
            .FirstOrDefaultAsync(p => p.Id == id);
            if (pedido == null)
            {
                return null;
            }
            PedidoFindIdResponse response = _mapper.Map<PedidoFindIdResponse>(pedido);
            return response;
        }
        
        public static decimal? SumaPedido(List<Formula>? listaForm, List<ProdTerm>? listaProdTerm)
        {
            decimal? total = 0;

            if (listaForm.Count() != 0 || listaForm != null)
            {
                foreach (var formula in listaForm)
                {
                    if (formula.Estado.ToUpper().Trim() != "DEVUELTO")
                    {
                        total += formula.Costo * formula.Cantidad;
                    }

                }
            }
            if (listaProdTerm.Count() != 0 || listaProdTerm != null)
            {
                foreach (var prod in listaProdTerm)
                {
                    if (prod.Estado.ToUpper().Trim() != "DEVUELTO")
                    {
                        total += prod.Costo * prod.Cantidad;
                    }

                }
            }

            return total;
        }
        public static decimal? SumaCobro(List<Cobro>? listaCobro)
        {
            decimal? total = 0;
            if (listaCobro.Count() == 0 || listaCobro == null)
            {
                return 0;
            }
            foreach (var cobro in listaCobro)
            {
                total += cobro.Importe;
            }
            return total;
        }

    }
}