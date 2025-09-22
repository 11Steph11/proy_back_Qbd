using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;
using Proy_back_QBD.Response;
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


        public async Task<CajaFindAllRes?> Obtener(CajaFindAllReq request)
        {
            List<Cobro> caja = await _context.Cobros
                    .Include(i => i.Pedido.Paciente.Persona)
                    .Where(w =>
                        DateOnly.FromDateTime(w.FechaCreacion) >= request.FechaInicio &&
                        DateOnly.FromDateTime(w.FechaCreacion) <= request.FechaFinal)
                    .ToListAsync();

            List<MovimientosEfectivo> movimientos = caja.Select(s => new MovimientosEfectivo
            {
                CUO_R = "BDRP-" + s.PedidoId,
                CUO_C = "BDRC-" + s.Id,
                Fecha = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(s.FechaCreacion)),
                Dni = s.Pedido.Paciente.DniApoderado ?? s.Pedido.Paciente.Persona.Dni,
                Paciente = s.Pedido.Paciente.Persona.Nombres + " " + s.Pedido.Paciente.Persona.Apellidos,
                FechaPedido = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(s.Pedido.FechaCreacion)),
                Modalidad = s.Modalidad,
                Importe = s.Importe,
                Hora = TimeOnly.FromDateTime(ZonaHoraria.AjustarZona(s.FechaCreacion)),
                Turno = s.Turno,
                BolFac = s.Pedido.ComprobanteElectronico
            }).ToList();
            RecaudacionDelDia recaudDia = new();
            RPagosDelDia pagosDia = new();
            RPagosAnteriores pagosAnteriores = new();
            BQPagosDelDia bqPagos = new();
            DateOnly Hoy = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(DateTime.Now));
            foreach (var item in movimientos)
            {
                if (item.Modalidad.Trim().ToUpper() == "YAPE"
                || item.Modalidad.Trim().ToUpper() == "PLIN"
                || item.Modalidad.Trim().ToUpper() == "DEPOSITO"
                || item.Modalidad.Trim().ToUpper() == "TARJETA")
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
                if (recaudDia.Total == null)
                {
                    recaudDia.Total = 0;
                }
                recaudDia.Total += item.Importe;
            }
            CajaFindAllRes? response = new CajaFindAllRes
            {
                Movimientos = movimientos,
                RecaudacionDelDia = recaudDia,
                RPagosDelDia = pagosDia,
                RPagosAnteriores = pagosAnteriores,
                BQPagos = bqPagos
            };

            return response;
        }
    }

}
