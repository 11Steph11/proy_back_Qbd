using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    
    [Table("sedes")]
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }  // Puede ser nulo
        public string? Nombre { get; set; }  // Puede ser nulo                
        public string? Direccion { get; set; }  // Puede ser nulo               
        [ForeignKey("IdUsuario")]
        public User? Usuario { get; set; }  // Puede ser nulo                
        [Column("id_usuario")]
        public int? IdUsuario { get; set; }  // Puede ser nulo      
        public string? Telefono { get; set; }  // Puede ser nulo                                   
        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateOnly? FechaCreacion { get; set; }  // Puede ser nulo                
    }

}