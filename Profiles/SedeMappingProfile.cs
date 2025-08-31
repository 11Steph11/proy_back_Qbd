// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class SedeMappingProfile : Profile
    {
        public SedeMappingProfile()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<SedeCreateReq, Sede>();
            // Otros mapeos si es necesario
        }
    }

}