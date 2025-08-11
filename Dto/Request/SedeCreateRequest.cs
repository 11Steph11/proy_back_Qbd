using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    

    public class SedeCreateRequest
    {
        public string? Sede { get; set; }  // Puede ser nulo                
        public string? Direccion { get; set; }  // Puede ser nulo               
        public string? DNI { get; set; }  // Puede ser nulo      
        public string? Responsable { get; set; }  // Puede ser nulo                                   
        public string? Telefono { get; set; }  // Puede ser nulo                                   
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo                                   
        public string? Usuario { get; set; }  // Puede ser nulo                                   
    }

}