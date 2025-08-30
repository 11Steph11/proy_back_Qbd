using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Request
{

    [Table("tipos_usuario")]
    public class TipoUsuario
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }  // Puede ser nulo 
        [Column("nombre")]
        public string? Nombre { get; set; }  // Puede ser nulo
    }

}