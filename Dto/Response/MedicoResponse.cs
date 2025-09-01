using System.Text.Json.Serialization;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Dto.Response
{
    public class MedicoFindAllResponse
    {
        public int? Id { get; set; }
        public string? EspecialidadFk { get; set; }
        public string? NumeroEspecialidad { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Cmp { get; set; }
    }
    public class MedicoCreateResponse
    {
        public string? Msg { get; set; }  // Puede ser nulo      
        public Medico? MedicoRes { get; set; }
    }
    public class MedicoUpdateResponse
    {
        public string? Msg { get; set; }  // Puede ser nulo      
        public Medico? MedicoRes { get; set; }
    }
}