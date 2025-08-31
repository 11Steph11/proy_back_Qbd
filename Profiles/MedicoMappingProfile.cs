// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class MedicoMappingProfile : Profile
    {
        public MedicoMappingProfile()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<MedicoCreateReq, Medicos>();
            // Otros mapeos si es necesario
        }
    }

}