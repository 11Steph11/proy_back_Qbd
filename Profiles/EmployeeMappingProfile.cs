// ApoderadoMappingProfile.cs
using AutoMapper;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Models; // Asegúrate de incluir el espacio de nombres correcto

namespace Proy_back_QBD.Profiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            // Mapeo entre ApoderadoCreate y Apoderado
            CreateMap<EmployeeCreateReq, Employee>();
            CreateMap<EmployeeUpdateReq, Employee>();
            // Otros mapeos si es necesario
        }
    }

}