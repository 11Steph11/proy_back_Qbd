using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;
using Proy_back_QBD.Response;
using Proy_back_QBD.Response.Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Util;

namespace Proy_back_QBD.Services
{
    public class CajaService : ICajaService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public CajaService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<CajaFindAllRes?> Obtener(CajaFindAllReq request, int sedeId)
        {
            RecaudacionDelDia recaudDia = new();
            RPagosDelDia pagosDia = new();
            RPagosAnteriores pagosAnteriores = new();
            BQPagosDelDia bqPagos = new();
            Ventas ventas = new Ventas();
            List<DeudasPendientes> DeudasP = new();

            List<Cobro> caja = await _context.Cobros
                    .Include(i => i.Pedido.Paciente.Persona)
                    .Include(i => i.Pedido.Formulas)
                    .Include(i => i.Pedido.ProdTerms)
                    .Where(w =>
                        DateOnly.FromDateTime(w.FechaCreacion) >= request.FechaInicio
                        && DateOnly.FromDateTime(w.FechaCreacion) <= request.FechaFinal && w.SedeId == sedeId
                        )
                    .ToListAsync();

            List<Movimientos> movsPend = caja
            .Where(w => w.Pedido.Estado != "DEVUELTO" && w.Pedido.Saldo != 0)
            .Select(s => new Movimientos
            {
                CUO_R = "P-" + s.PedidoId,
                CUO_C = "BDRC-" + s.Id,
                FechaCobro = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(s.FechaCreacion)),
                Dni = !string.IsNullOrEmpty(s.Pedido.Paciente.DniApoderado)
      ? s.Pedido.Paciente.DniApoderado
      : s.Pedido.Paciente.Persona.Dni,
                Paciente = s.Pedido.Paciente.Persona.NombreCompleto,
                FechaPedido = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(s.Pedido.FechaCreacion)),
                Modalidad = s.Modalidad,
                Estado = s.Pedido.Estado,
                Importe = s.Importe,
                Hora = TimeOnly.FromDateTime(ZonaHoraria.AjustarZona(s.FechaCreacion)),
                Turno = s.Turno,
                BolFac = s.Pedido.ComprobanteElectronico
            })
            .ToList();

            List<int?> idMovsTerm = caja
            .Where(w => w.Pedido.Estado != "DEVUELTO" && w.Pedido.Saldo == 0)
            .Select(s => s.PedidoId)
            .ToList();
            List<Movimientos> movsTerm = new();
            Console.WriteLine("CODIGOS PEDIDOOOOOOOOOO" + idMovsTerm);
            if (idMovsTerm != null)
            {
                movsTerm = await _context.Cobros
                .Include(i => i.Pedido.Paciente.Persona)
                .Include(i => i.Pedido.Formulas)
                .Include(i => i.Pedido.ProdTerms)
                .Where(w => idMovsTerm.Contains(w.PedidoId))
                .Select(s => new Movimientos
                {
                    CUO_R = "Z-" + s.PedidoId,
                    CUO_C = "BDRC-" + s.Id,
                    FechaCobro = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(s.FechaCreacion)),
                    Dni = s.Pedido.Paciente.DniApoderado ?? s.Pedido.Paciente.Persona.Dni,
                    Paciente = s.Pedido.Paciente.Persona.NombreCompleto,
                    FechaPedido = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(s.Pedido.FechaCreacion)),
                    Modalidad = s.Modalidad,
                    Estado = s.Pedido.Estado,
                    Importe = s.Importe,
                    Hora = TimeOnly.FromDateTime(ZonaHoraria.AjustarZona(s.FechaCreacion)),
                    Turno = s.Turno,
                    BolFac = s.Pedido.ComprobanteElectronico
                })
                .ToListAsync();
            }
            List<Movimientos> movimientos = new List<Movimientos>();
            if (movsPend != null) movimientos.AddRange(movsPend);
            if (movsTerm != null) movimientos.AddRange(movsTerm);

            DateOnly Hoy = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(DateTime.Now));
            foreach (var item in movimientos)
            {
                if (item.Modalidad.Trim().ToUpper() == "YAPE"
                || item.Modalidad.Trim().ToUpper() == "PLIN"
                || item.Modalidad.Trim().ToUpper() == "DEPOSITO"
                || item.Modalidad.Trim().ToUpper() == "TARJETA CREDITO"
                || item.Modalidad.Trim().ToUpper() == "TARJETA DEBITO"
                )
                {
                    recaudDia.Electronico += item.Importe;
                    if (!string.IsNullOrEmpty(item.BolFac))
                    {
                        bqPagos.Total += item.Importe;
                        bqPagos.Electronico += item.Importe;
                    }

                    if (item.FechaPedido != Hoy)
                    {
                        pagosAnteriores.Electronico += item.Importe;
                        pagosAnteriores.Total += item.Importe;
                    }
                    else
                    {
                        pagosDia.Electronico += item.Importe;
                        pagosDia.Total += item.Importe;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(item.BolFac))
                    {
                        bqPagos.Total += item.Importe;
                        bqPagos.Efectivo += item.Importe;
                    }
                    if (item.FechaPedido != Hoy)
                    {
                        pagosAnteriores.Efectivo += item.Importe;
                        pagosAnteriores.Total += item.Importe;
                    }
                    else
                    {
                        pagosDia.Efectivo += item.Importe;
                        pagosDia.Total += item.Importe;
                    }
                    recaudDia.Efectivo += item.Importe;
                }
            }
            recaudDia.Total = 0;
            recaudDia.Total += pagosDia.Total + pagosAnteriores.Total;

            List<Pedido> ventasP = await _context.Pedidos
                   .Include(i => i.Paciente.Persona)
                   .Where(w =>
                       DateOnly.FromDateTime(w.FechaCreacion) >= request.FechaInicio
                       && DateOnly.FromDateTime(w.FechaCreacion) <= request.FechaFinal && w.SedeId == sedeId
                       )
                   .ToListAsync();

            ventas.Total = 0;
            ventas.Total = ventasP.Sum(p => p.Total);
            ventas.Adelantos = ventasP.Sum(p => p.Adelanto);
            ventas.Saldo = ventasP.Sum(p => p.Saldo);

            DeudasP = ventasP
            .Where(w => w.Saldo != 0)
            .Select(s => new DeudasPendientes
            {
                CUO_R = "BDRP-" + s.Id,
                FechaPedido = DateOnly.FromDateTime(s.FechaCreacion),
                Recibo = s.Id.ToString(),
                Dni = s.Paciente.Persona.Dni ?? s.Paciente.DniApoderado,
                Paciente = s.Paciente.Persona.NombreCompleto,
                Telefono = s.Paciente.Persona.Telefono,
                Importe = s.Total,
                Adelanto = s.Adelanto,
                Saldo = s.Saldo,
                BolFac = s.ComprobanteElectronico,
            }).ToList();

            CajaFindAllRes? response = new CajaFindAllRes
            {
                Movimientos = movimientos,
                RecaudacionDelDia = recaudDia,
                RPagosDelDia = pagosDia,
                RPagosAnteriores = pagosAnteriores,
                BQPagos = bqPagos,
                Ventas = ventas,
                Deudas = DeudasP
            };

            return response;
        }
    }

}
