namespace Proy_back_QBD.Dto.Request
{
    public class UsuarioLoginReq
    {
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }
    }
    public class UsuarioCreateReq : PersonaCreateReq
    {
        public int? TipoId { get; set; }
        public string? Contrasena { get; set; }
        public TimeOnly? HorarioEntrada { get; set; }
        public TimeOnly? HorarioSalida { get; set; }
        public string? Cmp { get; set; }
        public TimeOnly? HorarioAlmuerzo { get; set; }
        public TimeOnly? HorarioRegreso { get; set; }
    }
    public class UsuarioUpdateReq : PersonaUpdateReq
    {
        public string? Contrasena { get; set; }
        public int? TipoId { get; set; }
        public TimeOnly? HorarioEntrada { get; set; }
        public TimeOnly? HorarioSalida { get; set; }
        public string? Cmp { get; set; }
        public TimeOnly? HorarioAlmuerzo { get; set; }
        public TimeOnly? HorarioRegreso { get; set; }
    }
}
