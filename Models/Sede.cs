using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public int? EncargadoId { get; set; }  // Puede ser nulo              
        public Usuario? Encargado  { get; set; }  // Puede ser nulo              
        [Column("telefono")]
        public string? Telefono { get; set; }  // Puede ser nulo               
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
        [JsonIgnore]
        public List<Persona>? Personas { get; set; }
    }

}