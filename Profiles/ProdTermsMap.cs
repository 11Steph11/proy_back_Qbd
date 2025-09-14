// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class ProdTermsMap : Profile
    {
        public ProdTermsMap()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<ProdTermPedidoReq, ProdTerm>()
            .ForMember(a => a.Id, o => o.Ignore())
            .ForMember(a => a.ModificadorId, o => o.Ignore())
            .ForMember(a => a.PedidoId, o => o.Ignore())
            ;
            CreateMap<ProdTermUpdateReq, ProdTerm>()
            .ForMember(a => a.Id, opt => opt.Ignore())
            .ForMember(a => a.CreadorId, opt => opt.Ignore())
            ;
            CreateMap<ProdTerm,ProdTermPedido >();
            CreateMap<ProdTermCreateReq,ProdTerm >();
            
        }
    }

}