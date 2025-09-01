using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    [Table("especialidad")]
    public class Especialidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }  // Puede ser nulo        
        [Column("nombre")]
        public string? Nombre { get; set; }  // Puede ser nulo        
        [Column("fecha_creacion")]
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo
        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }  // Puede ser nulo
        [Column("creador")]
        public int? Creador { get; set; }  // Puede ser nulo
        [Column("modificador")]
        public int? Modificador { get; set; }  // Puede ser nulo

    }

}