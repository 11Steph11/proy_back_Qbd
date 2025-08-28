using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{

    [Table("personas")]
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        [Column("id")]
        public int? Id { get; set; }  // Puede ser nulo 
        [Column("nombres")]
        public string? Nombres { get; set; }  // Puede ser nulo
        [Column("apellido_paterno")]
        public string? ApellidoPaterno { get; set; }  // Puede ser nulo
        [Column("apellido_materno")]
        public string? ApellidoMaterno { get; set; }  // Puede ser nulo
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_nacimiento")]
        public DateOnly? FechaNacimiento { get; set; }  // Puede ser nulo
        [Column("dni")]
        public string? Dni { get; set; }  // Puede ser nulo
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
        [ForeignKey("SedeId")]
        public Sede? Sede { get; set; }  // Puede ser nulo
        [Column("sede_id")]
        public int? SedeId { get; set; }  // Puede ser nulo
        [Column("telefono")]
        public string? Telefono { get; set; }  // Puede ser nulo        
    }

}