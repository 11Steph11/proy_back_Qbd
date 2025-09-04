using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    [Table("pacientes")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }  // Puede ser nulo
        [Column("apoderado")]
        public string? Apoderado { get; set; }
        [Column("dni_apoderado")]
        public string? DniApoderado { get; set; }
        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo
        [Column("fecha_modificacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? FechaModificacion { get; set; }  // Puede ser nulo
        [Column("creador")]
        public int? Creador { get; set; }  // Puede ser nulo
        [Column("modificador")]
        public int? Modificador { get; set; }  // Puede ser nulo
        [ForeignKey("PersonaId")]
        public Persona? PersonaFk { get; set; }  // Puede ser nulo
        [Column("persona_id")]
        public int? PersonaId { get; set; }  // Puede ser nulo
        [Column("condicion_fecha")]
        public bool? CondicionFecha { get; set; }
    }

}