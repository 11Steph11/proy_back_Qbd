using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto.Response
{
    public class UsuarioLoginRes
    {
        public string? NombreCompleto { get; set; }
        public string? TipoUsuario { get; set; }
        public string? Sede { get; set; }
        public string? Usuario { get; set; }
    }
    public class UsuarioLoginDataRes
    {
        public string? NombreCompleto { get; set; }
        public string? TipoUsuario { get; set; }
        public int? TipoId { get; set; }
        public string? Sede { get; set; }
        public int? SedeId { get; set; }
        public int? Id { get; set; }
    }
    public class UsuarioListaRes
    {
        public int? Id { get; set; }
        public string? Contrasena { get; set; }
        public TimeOnly? HorarioEntrada { get; set; }
        public TimeOnly? HorarioSalida { get; set; }
        public TimeOnly? HorarioAlmuerzo { get; set; }
        public TimeOnly? HorarioRegreso { get; set; }
        public string? Cmp { get; set; }
        public PersonaRes? PersonaRes { get; set; }
        public string? TipoUsuario { get; set; }
        public string? Codigo { get; set; }
    }
    public class UsuarioByIdRes
    {
        public int? Id { get; set; }
        public string? Contrasena { get; set; }
        public TimeOnly? HorarioEntrada { get; set; }
        public TimeOnly? HorarioSalida { get; set; }
        public TimeOnly? HorarioAlmuerzo { get; set; }
        public TimeOnly? HorarioRegreso { get; set; }
        public string? Cmp { get; set; }
        public PersonaRes? PersonaRes { get; set; }
        public string? TipoUsuario { get; set; }
        public string? Codigo { get; set; }
    }
}