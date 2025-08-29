using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    

    public class SedeCreateReq
    {
        public string? Nombre { get; set; }  // Puede ser nulo                
        public string? Direccion { get; set; }  // Puede ser nulo               
        public int? Encargado { get; set; }  // Puede ser nulo                                   
        public string? Telefono { get; set; }  // Puede ser nulo                                   
        public int? Creador { get; set; }  // Puede ser nulo                                   
        public int? Modificador { get; set; }  // Puede ser nulo                                   
    }

}