using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Request
{
    public class SedeCreateReq
    {
        public string? Nombre { get; set; }  // Puede ser nulo                
        public string? Direccion { get; set; }  // Puede ser nulo               
        public string? Encargado { get; set; }  // Puede ser nulo                                   
        public string? Telefono { get; set; }  // Puede ser nulo                                   
        public int? CreadorId { get; set; }
    }
    public class GeneralReq
    {
        public int? Meta { get; set; }
        public string? MsgTerminado { get; set; }
        public string? MsgSeguimiento { get; set; }
        public string? MsgCumple { get; set; }
        public string? MsgGpt { get; set; }
    }
}