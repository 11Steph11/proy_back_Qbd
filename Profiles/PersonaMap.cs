// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class PersonaMappingProfile : Profile
    {
        public PersonaMappingProfile()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<PersonaCreateReq, Persona>()
            .ForMember(a => a.Id, options => options.Ignore())
            .ForMember(a => a.FechaCreacion, options => options.Ignore())
            .ForMember(a => a.Sede, options => options.Ignore())
            ;
            CreateMap<PersonaUpdateReq, Persona>()
            .ForMember(a => a.Id, options => options.Ignore())
            .ForMember(a => a.CreadorId, options => options.Ignore())
            .ForMember(a => a.FechaCreacion, options => options.Ignore())
            .ForMember(a => a.Sede, options => options.Ignore())
            ;
            CreateMap<Persona, PersonaRes>();
            CreateMap<Persona, PersonaRes2>();
        }
    }

}