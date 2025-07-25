using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{

    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }  // Puede ser nulo 
        public string? Contrasena { get; set; }  // Puede ser nulo        
        public string? Nombres { get; set; }  // Puede ser nulo
        [Column("apellido_paterno")]
        public string? ApellidoPaterno { get; set; }  // Puede ser nulo
        [Column("apellido_materno")]
        public string? ApellidoMaterno { get; set; }  // Puede ser nulo
        [ForeignKey("IdTipo")]
        public TipoUsuario? Tipo { get; set; }  // Puede ser nulo
        [Column("id_tipo")]
        public int? IdTipo { get; set; }  // Puede ser nulo
        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateOnly? FechaCreacion { get; set; }  // Puede ser nulo
        [ForeignKey("IdCreador")]
        public Usuario? Creador { get; set; }  // Puede ser nulo
        [Column("id_creador")]
        public int? IdCreador { get; set; }  // Puede ser nulo
        public string? DNI { get; set; }  // Puede ser nulo
        public string? CMP { get; set; }  // Puede ser nulo
        [ForeignKey("IdSede")]
        public Sede? Sede { get; set; }  // Puede ser nulo
        [Column("id_sede")]
        public int? IdSede { get; set; }  // Puede ser nulo
    }

}