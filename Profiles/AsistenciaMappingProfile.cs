// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class AsistenciaMappingProfile : Profile
    {
        public AsistenciaMappingProfile()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<AsistenciaCreateReq, Asistencia>();
            CreateMap<AsistenciaByDNIReq, Asistencia>();
            // Otros mapeos si es necesario
        }
    }

}