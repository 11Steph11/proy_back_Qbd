namespace Proy_back_QBD.Dto.Response
{
    public class TrabRellenarByCodRes
    {
        public string? Dni { get; set; }
        public string? NombreCompleto { get; set; }
        public TimeSpan? HoraAsignada { get; set; }
    }
    public class TrabRellenarByIdRes
    {
        public string? Codigo { get; set; }
        public string? Dni { get; set; }
        public string? Cmp { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraAlmuerzo { get; set; }
        public TimeSpan? HoraRegreso { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public int? IdSede { get; set; }
        public string? Contrasena { get; set; }
    }
}