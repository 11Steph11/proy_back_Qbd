namespace Proy_back_QBD.Dto.Request
{
    public class UsuarioLoginReq
    {
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }
    }
    public class UsuarioCreateReq
    {
        public int? TipoId { get; set; }
        public string? Contrasena { get; set; }
        public TimeOnly? HorarioEntrada { get; set; }
        public TimeOnly? HorarioSalida { get; set; }
        public PersonaCreateReq? Persona { get; set; }
        public string? Cmp { get; set; }
        public int? CreadorId { get; set; }
        public TimeOnly? HorarioAlmuerzo { get; set; }
        public TimeOnly? HorarioRegreso { get; set; }
    }
    public class UsuarioUpdateReq
    {
        public string? Contrasena { get; set; }
        public int? TipoId { get; set; }
        public TimeOnly? HorarioEntrada { get; set; }
        public TimeOnly? HorarioSalida { get; set; }
        public PersonaUpdateReq? Persona { get; set; }
        public string? Cmp { get; set; }
        public int? ModificadorId { get; set; }
        public TimeOnly? HorarioAlmuerzo { get; set; }
        public TimeOnly? HorarioRegreso { get; set; }
    }
}
