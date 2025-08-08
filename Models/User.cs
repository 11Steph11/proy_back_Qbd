using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{

    [Table("usuarios")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }  // Puede ser nulo 
        [Column("contrasena")]
        public string? Contrasena { get; set; }  // Puede ser nulo        
        [Column("codigo")]
        public string? Codigo { get; set; }  // Puede ser nulo
        [Column("nombres")]
        public string? Nombres { get; set; }  // Puede ser nulo
        [Column("apellido_paterno")]
        public string? ApellidoPaterno { get; set; }  // Puede ser nulo
        [Column("apellido_materno")]
        public string? ApellidoMaterno { get; set; }  // Puede ser nulo
        [ForeignKey("IdTipo")]
        public UserType? Tipo { get; set; }  // Puede ser nulo
        [Column("id_tipo")]
        public int? IdTipo { get; set; }  // Puede ser nulo
        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateOnly? FechaCreacion { get; set; }  // Puede ser nulo
        [ForeignKey("IdCreador")]
        public User? Creador { get; set; }  // Puede ser nulo
        [Column("id_creador")]
        public int? IdCreador { get; set; }  // Puede ser nulo
        [Column("dni")]
        public string? DNI { get; set; }  // Puede ser nulo
        [Column("cmp")]
        public string? CMP { get; set; }  // Puede ser nulo
        [ForeignKey("IdSede")]
        public Region? Sede { get; set; }  // Puede ser nulo
        [Column("id_sede")]
        public int? IdSede { get; set; }  // Puede ser nulo
    }

}