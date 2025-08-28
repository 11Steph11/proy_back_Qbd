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
        public int? Id { get; set; }
    }
}