namespace Proy_back_QBD.Dto.Response
{
    public class AttendanceCreateRes
    {
        public int? Id { get; set; }
        public TimeOnly? HoraMarcada { get; set; }
        public TimeSpan? Diferencia { get; set; }
    }
}