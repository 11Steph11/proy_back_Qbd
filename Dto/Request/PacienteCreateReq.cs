namespace Proy_back_QBD.Dto.Request{
    public class PacienteCreateReq
    {
        public string? Datos { get; set; }
        public string? DNI { get; set; }
        public string? Direccion { get; set; }
        public DateOnly? FechaNcto { get; set; }
        public string? Celular { get; set; }
        public string? DniApoderado { get; set; }
        public string? Apoderado { get; set; }
        public string? Aproximado { get; set; }
        public string? Usuario { get; set; }
    }
}
