// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class PedidoMappingProfile : Profile
    {
        public PedidoMappingProfile()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<PedidoCreateReq, Pedido>(); 
            CreateMap<PedidoUpdateReq, Pedido>()
            .ForMember(a => a.Id, opt => opt.Ignore())
            .ForMember(a => a.Creador, opt => opt.Ignore())
            ;
            // Otros mapeos si es necesario
        }
    }

}