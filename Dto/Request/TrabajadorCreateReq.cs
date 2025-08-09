namespace Proy_back_QBD.Dto.Request
{
    public class TrabajadorCreateReq:UsuarioCreateReq
    {
        public TimeSpan? HoraEntrada { get; set; }  // Puede ser nulo
        public TimeSpan? HoraAlmuerzo { get; set; }  // Puede ser nulo
        public TimeSpan? HoraRegreso { get; set; }  // Puede ser nulo
        public TimeSpan? HoraSalida { get; set; }  // Puede ser nulo
    }
}