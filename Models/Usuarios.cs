using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Puede ser nulo
        public string? Usuario { get; set; }  // Puede ser nulo        
        public string? Password { get; set; }  // Puede ser nulo
        [ForeignKey("Usuario")]
        [NotMapped]
        public Trabajadores? Trabajadores { get; set; }  // Puede ser nulo
    }
}