// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class TrabajadorMappingProfile : Profile
    {
        public TrabajadorMappingProfile()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<TrabajadorCreateReq, Trabajador>();
            CreateMap<TrabajadorUpdateReq, Trabajador>();
            // Otros mapeos si es necesario
        }
    }

}