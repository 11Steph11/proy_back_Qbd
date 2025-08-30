using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto.Response
{
    public class PersonaListaRes
    {  
        public int? Id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Dni { get; set; }
        public string? Sede { get; set; }
        public string? Telefono { get; set; }
    }
}