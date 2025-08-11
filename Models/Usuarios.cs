using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    public class Usuarios
    {
        public string? Usuario { get; set; }  // Puede ser nulo        
        public string? Password { get; set; }  // Puede ser nulo
        [ForeignKey("Usuario")]
        public Trabajadores? Trabajadores { get; set; }  // Puede ser nulo
    }
}