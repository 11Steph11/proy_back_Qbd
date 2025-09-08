using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{

    [Table("personas")]
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }  // Puede ser nulo 
        [Column("nombres")]
        public string? Nombres { get; set; }  // Puede ser nulo
        [Column("apellidos")]
        public string? Apellidos { get; set; }  // Puede ser nulo
        [Column("fecha_nacimiento")]
        public DateOnly? FechaNacimiento { get; set; }  // Puede ser nulo
        [Column("dni")]
        [Length(8,8)]
        public required string Dni { get; set; }  // Puede ser nulo
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }  // Puede ser nulo
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_modificacion")]
        public DateTime FechaModificacion { get; set; }  // Puede ser nulo
        [Column("creador_id")]
        public int? CreadorId { get; set; }
        [JsonIgnore]
        public Usuario? Creador { get; set; }
        [Column("modificador_id")]
        public int? ModificadorId { get; set; }
        public Usuario? Modificador { get; set; }
        [Column("sede_id")]
        public int? SedeId { get; set; }  // Puede ser nulo
        [JsonIgnore]
        public Sede? Sede { get; set; }  // Puede ser nulo
        [Column("telefono")]
        public string? Telefono { get; set; }  // Puede ser nulo
        [JsonIgnore]
        public List<Usuario>? Usuarios { get; set; }  // Puede ser nulo
        [JsonIgnore]
        public List<Medico>? Medicos { get; set; }  // Puede ser nulo
        [JsonIgnore]
        public List<Paciente>? Pacientes { get; set; }  // Puede ser nulo
    }

}