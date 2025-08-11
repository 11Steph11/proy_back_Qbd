namespace Proy_back_QBD.Dto.Response
{
    public class TrabajadorRellenarByCodAsistRes
    {
        public string? Dni { get; set; }
        public string? NombreCompleto { get; set; }
        public TimeOnly? HoraAsignada { get; set; }
    }
    public class TrabRellenarByCodGestRes
    {
        public string? Codigo { get; set; }
        public string? DniCmp { get; set; }
        public string? Datos { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public TimeOnly? HoraEntrada { get; set; }
        public TimeOnly? HoraAlmuerzo { get; set; }
        public TimeOnly? HoraRegreso { get; set; }
        public TimeOnly? HoraSalida { get; set; }
        public int? IdSede { get; set; }
        public string? Contrasena { get; set; }
    }
}