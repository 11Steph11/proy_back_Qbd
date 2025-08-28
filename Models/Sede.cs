using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{

    [Table("sedes")]
    public class Sede
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }  // Puede ser nulo
        [Column("nombre")]
        public string? Nombre { get; set; }
        [Column("direccion")]
        public string? Direccion { get; set; }  // Puede ser nulo               
        [Column("encargado")]
        public int? Encargado { get; set; }  // Puede ser nulo               
        [Column("telefono")]
        public string? Telefono { get; set; }  // Puede ser nulo               
        [Column("fecha_creacion")]
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo               
    }

}