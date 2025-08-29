namespace Proy_back_QBD.Dto.Request{
    public class UsuarioCreate:PersonaCreateReq
    {
        public int? TipoId { get; set; }
        public string? Contrasena { get; set; }
        public TimeOnly? HorarioEntrada { get; set; }
        public TimeOnly? HorarioSalida { get; set; }
        public string? Cmp { get; set; }
        public TimeOnly? HorarioAlmuerzo { get; set; }
        public TimeOnly? HorarioRegreso { get; set; }
    }
}
