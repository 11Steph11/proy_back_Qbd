using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{

    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }  // Puede ser nulo 
        [Column("contrasena")]
        public string? Contrasena { get; set; }  // Puede ser nulo        
        [ForeignKey("TipoId")]
        [JsonIgnore]
        public TipoUsuario? Tipo { get; set; }  // Puede ser nulo
        [Column("tipo_id")]
        public int? TipoId { get; set; }  // Puede ser nulo
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_creacion")]
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }  // Puede ser nulo
        [Column("creador")]
        public int? Creador { get; set; }  // Puede ser nulo
        [Column("modificador")]
        public int? Modificador { get; set; }  // Puede ser nulo
        [Column("horario_entrada")]
        public TimeOnly? HorarioEntrada { get; set; }  // Puede ser nulo
        [Column("horario_salida")]
        public TimeOnly? HorarioSalida { get; set; }  // Puede ser nulo
        [ForeignKey("PersonaId")]
        public Persona? Persona { get; set; }  // Puede ser nulo
        [Column("persona_id")]
        public int? PersonaId { get; set; }  // Puede ser nulo
        [Column("cmp")]
        public string? Cmp { get; set; }  // Puede ser nulo
        [Column("horario_almuerzo")]
        public TimeOnly? HorarioAlmuerzo { get; set; }  // Puede ser nulo
        [Column("horario_regreso")]
        public TimeOnly? HorarioRegreso { get; set; }  // Puede ser nulo
        [Column("codigo")]
        public string? Codigo { get; set; }
        
    }

}