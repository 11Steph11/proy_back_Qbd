using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto.Response
{
    public class PersonaRes
    {
        public int? Id { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Dni { get; set; }
        public string? Sede { get; set; }
        public int? SedeId { get; set; }
        public string? Telefono { get; set; }
    } 
}