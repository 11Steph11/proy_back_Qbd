using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto.Response
{
    public class UsuarioLoginRes
    {
        public string? NombreCompleto { get; set; }
        public string? Rol { get; set; }
        public string? Sede { get; set; }
        public int? IdUsuario { get; set; }
        [NotMapped]
        public string? Contrasena { get; set; }
    }
}