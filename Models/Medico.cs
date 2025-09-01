using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{
    [Table("medicos")]
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }  // Puede ser nulo
        [ForeignKey("EspecialidadId")]
        [JsonIgnore]
        public Especialidad? Especialidad { get; set; }
        [Column("especialidad_id")]
        public int? EspecialidadId { get; set; }  // Puede ser nulo     
        [Column("numero_especialidad")]
        public string? NumeroEspecialidad { get; set; }
        [ForeignKey("PersonaId")]
        [JsonIgnore]
        public Persona? PersonaFk { get; set; }  // Puede ser nulo
        [Column("persona_id")]
        public int? PersonaId { get; set; }  // Puede ser nulo
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
        [Column("cmp")]
        public string? Cmp { get; set; }
    }

}