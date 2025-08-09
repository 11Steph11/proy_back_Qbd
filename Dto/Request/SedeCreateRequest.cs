using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    

    public class SedeCreateRequest
    {
        public string? Nombre { get; set; }  // Puede ser nulo                
        public string? Direccion { get; set; }  // Puede ser nulo               
        public int? IdUsuario { get; set; }  // Puede ser nulo      
        public string? Telefono { get; set; }  // Puede ser nulo                                   
    }

}