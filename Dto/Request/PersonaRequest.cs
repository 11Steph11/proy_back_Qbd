namespace Proy_back_QBD.Dto.Request
{
    public class PersonaCreateReq
    {
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Dni { get; set; }
        public int? Creador { get; set; }
        public int? Modificador { get; set; }
        public int? SedeId { get; set; }
        public int? Telefono { get; set; }
    }
    public class PersonaUpdateReq
    {
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
         public string? Dni { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? Modificador { get; set; }
        public int? SedeId { get; set; }
        public int? Telefono { get; set; }
    }
}
