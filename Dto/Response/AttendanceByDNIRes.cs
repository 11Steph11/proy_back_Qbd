namespace Proy_back_QBD.Dto.Response
{
    public class FechaConHoras
    {
        public DateOnly Fecha { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public TimeOnly HoraAlmuerzo { get; set; }
        public TimeOnly HoraRegreso { get; set; }
        public TimeOnly HoraSalida { get; set; }
    }
    public class AttendanceByDNIRes
    {
        public string? Nombre { get; set; }
        public List<FechaConHoras>? ListaAsistencia { get; set; }
    }
}