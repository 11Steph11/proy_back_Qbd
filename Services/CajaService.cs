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
            DateOnly FecFinal = request.FechaFinal.AddDays(1);
            var peruOffset = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time").GetUtcOffset(DateTime.UtcNow);
            List<Cobro> caja = await _context.Cobros
                    .Include(i => i.Pedido.Paciente.Persona)
                    .Include(i => i.Pedido.Formulas)
                    .Include(i => i.Pedido.ProdTerms)
                    .Where(w =>
                        DateOnly.FromDateTime(w.FechaCreacion.AddMinutes(peruOffset.TotalMinutes)) >= request.FechaInicio
                        && DateOnly.FromDateTime(w.FechaCreacion.AddMinutes(peruOffset.TotalMinutes)) <= request.FechaFinal && w.SedeId == sedeId
                        )
                    .ToListAsync();

            List<Movimientos> movsTotal = caja
            .Where(w => w.Pedido.Estado != "DEVUELTO")
            .OrderByDescending(odb => odb.Id)
            .Select(s => new Movimientos
            {
                CUO_R = "P" + s.PedidoId,
                CUO_C = "C" + s.Id,
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

            List<int> pedidosId = caja
            .Where(w => w.Pedido.Estado != "DEVUELTO")
            .Select(s => s.PedidoId)
            .ToList();
            List<MovTerm> MovsAnt = await _context.Cobros
            .Where(w => pedidosId.Contains(w.PedidoId) && DateOnly.FromDateTime(w.FechaCreacion.AddMinutes(peruOffset.TotalMinutes)) < request.FechaInicio)
            .Select(s => new MovTerm
            {
                Modalidad = s.Modalidad,
                Importe = s.Importe,
            }).ToListAsync();

            List<int> idMovsTerm = caja
            .Where(w => w.Pedido.Estado != "DEVUELTO" && w.Pedido.Saldo == 0 && w.Pedido.Recibo != null)
            .Select(s => s.PedidoId)
            .ToList();
            List<UltimosCobros?> UltimosCobros = await _context.Cobros
            .Where(w => idMovsTerm.Contains(w.PedidoId))
            .GroupBy(gb => gb.PedidoId)
            .Select(s => new UltimosCobros
            {
                PedidoId = s.Key,
                CobroId = s.Max(x => x.Id)
            })
            .ToListAsync();

            List<int> idUltimosC = UltimosCobros.Select(s => s.CobroId).ToList();
            List<int> idCajaTerms = caja.Where(w => w.Pedido.Saldo == 0 && w.Pedido.Recibo != null).Select(s => s.Id).ToList();

            List<MovTerm> movsTerm = new();
            List<int> resultadoRec = idCajaTerms.Where(w => idUltimosC.Contains(w)).ToList();


            if (idMovsTerm.Count > 0)
            {
                movsTerm = await _context.Cobros
               .Where(w => resultadoRec.Contains(w.Id))
               .Select(s => new MovTerm
               {
                   Modalidad = s.Modalidad,
                   Importe = s.Importe
               })
               .ToListAsync();
            }
            List<Movimientos> movimientos = new List<Movimientos>();
            if (movsTotal != null) movimientos.AddRange(movsTotal);

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
                    pagosDia.Electronico += item.Importe;
                }
                else
                {
                    pagosDia.Efectivo += item.Importe;
                    recaudDia.Efectivo += item.Importe;
                }
                pagosDia.Total += item.Importe;
            }
            foreach (var item in movsTerm)
            {
                if (item.Modalidad.Trim().ToUpper() == "YAPE"
                || item.Modalidad.Trim().ToUpper() == "PLIN"
                || item.Modalidad.Trim().ToUpper() == "DEPOSITO"
                || item.Modalidad.Trim().ToUpper() == "TARJETA CREDITO"
                || item.Modalidad.Trim().ToUpper() == "TARJETA DEBITO"
                )
                {
                    bqPagos.Electronico += item.Importe;
                }
                else
                {
                    bqPagos.Efectivo += item.Importe;
                }
                bqPagos.Total += item.Importe;
            }

            foreach (var item in MovsAnt)
            {
                if (item.Modalidad.Trim().ToUpper() == "YAPE"
                || item.Modalidad.Trim().ToUpper() == "PLIN"
                || item.Modalidad.Trim().ToUpper() == "DEPOSITO"
                || item.Modalidad.Trim().ToUpper() == "TARJETA CREDITO"
                || item.Modalidad.Trim().ToUpper() == "TARJETA DEBITO"
                )
                {
                    pagosAnteriores.Electronico += item.Importe;
                }
                else
                {
                    pagosAnteriores.Efectivo += item.Importe;
                }
                pagosAnteriores.Total += item.Importe;
            }

            recaudDia.Total = 0;
            recaudDia.Total += pagosDia.Total + pagosAnteriores.Total;

            List<Pedido> ventasP = await _context.Pedidos
                   .Include(i => i.Paciente.Persona)
                   .Where(w =>
                       DateOnly.FromDateTime(w.FechaCreacion.AddMinutes(peruOffset.TotalMinutes)) >= request.FechaInicio
                       && DateOnly.FromDateTime(w.FechaCreacion.AddMinutes(peruOffset.TotalMinutes)) < FecFinal && w.SedeId == sedeId
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
