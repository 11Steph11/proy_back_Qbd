using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Request
{


    public class SedeCreateReq
    {
        public string? Nombre { get; set; }  // Puede ser nulo                
        public string? Direccion { get; set; }  // Puede ser nulo               
        public int? Encargado { get; set; }  // Puede ser nulo                                   
        public string? Telefono { get; set; }  // Puede ser nulo                                   
        public int? CreadorId { get; set; }
    }
    public class SedeFindAllResponse
    {
        public int Id { get; set; }  // Puede ser nulo
        public required string Nombre { get; set; }
        public string? Direccion { get; set; }  // Puede ser nulo               
        public int? Encargado { get; set; }  // Puede ser nulo               
        public string? Telefono { get; set; }  // Puede ser nulo   
    }

}