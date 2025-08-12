// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class PacienteMappingProfile : Profile
    {
        public PacienteMappingProfile()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<PacienteCreateReq, Pacientes>();
            // Otros mapeos si es necesario
        }
    }

}