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


        public async Task<List<CajaFindAllRes?>> Obtener(CajaFindAllReq request)
        {
            List<CajaFindAllRes>? response = await _context.Cobros
                                            .Include(i => i.Pedido.Paciente.Persona)
                                            .Where(w => DateOnly.FromDateTime(w.FechaCreacion) >= request.FechaInicio
                                            && DateOnly.FromDateTime(w.FechaCreacion) <= request.FechaFinal)
                                            .Select(s => new CajaFindAllRes
                                            {
                                                CUO_R = "BDRP-" + s.PedidoId.ToString(),
                                                CUO_C = "BDRC-" + s.Id.ToString(),
                                                Fecha = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(s.FechaCreacion)),
                                                Dni = s.Pedido.Paciente.DniApoderado == null ? s.Pedido.Paciente.Persona.Dni : s.Pedido.Paciente.DniApoderado,
                                                Paciente = s.Pedido.Paciente.Persona.Nombres + " " + s.Pedido.Paciente.Persona.Apellidos,
                                                FechaPedido = DateOnly.FromDateTime(ZonaHoraria.AjustarZona(s.Pedido.FechaCreacion)),
                                                Modalidad = s.Modalidad,
                                                Importe = s.Importe.ToString(),
                                                Hora = TimeOnly.FromDateTime(ZonaHoraria.AjustarZona(s.FechaCreacion)),
                                                Turno = s.Turno,
                                                BolFac = s.Pedido.ComprobanteElectronico,
                                            })                                            
                                            .ToListAsync();
            
            return response;
        }
    }

}
