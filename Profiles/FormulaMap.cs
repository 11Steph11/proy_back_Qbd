// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class FormulaMap : Profile
    {
        public FormulaMap()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<FormulaCreateReq, Formula>()
            .ForMember(a => a.Id, o => o.Ignore())
            .ForMember(a => a.ModificadorId, o => o.Ignore())
            .ForMember(a => a.PedidoId, o => o.Ignore())
            ; 
            CreateMap<PedidoUpdateReq, Pedido>()
            .ForMember(a => a.Id, opt => opt.Ignore())
            .ForMember(a => a.CreadorId, opt => opt.Ignore())
            ;
            // Otros mapeos si es necesario
        }
    }

}