using System.Text.Json.Serialization;

namespace Proy_back_QBD.Dto.Request
{
    public class PersonaCreateReq
    {
        public string? NombreCompleto { get; set; }
        public string? Apellidos { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Dni { get; set; }
        public int? CreadorId { get; set; }
        public int? SedeId { get; set; }
        public string? Telefono { get; set; }
    }
    public class PersonaUpdateReq
    {
        public string? NombreCompleto { get; set; }
        public string? Apellidos { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Dni { get; set; }
        public int? SedeId { get; set; }
        public string? Telefono { get; set; }
        public int? ModificadorId { get; set; }
    }
}
