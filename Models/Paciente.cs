using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public DateTime FechaCreacion { get; set; }  // Puede ser nulo
        [Column("fecha_modificacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaModificacion { get; set; }  // Puede ser nulo
        [Column("creador_id")]
        public int CreadorId { get; set; }
        [JsonIgnore]
        public Usuario? Creador { get; set; }
        [Column("modificador_id")]
        public int ModificadorId { get; set; }
        [JsonIgnore]
        public Usuario? Modificador { get; set; }
        [Column("persona_id")]
        public int PersonaId { get; set; }  // Puede ser nulo
        [JsonIgnore]
        public Persona? Persona { get; set; }  // Puede ser nulo
        [Column("condicion_fecha")]
        public bool? CondicionFecha { get; set; }
        [JsonIgnore]
        public List<Pedido>? Pedidos { get; set; }
    }

}