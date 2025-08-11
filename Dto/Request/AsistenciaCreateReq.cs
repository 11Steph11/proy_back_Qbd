using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{


    public class AsistenciaCreateReq
    {
        public string? Tipo { get; set; }  // Puede ser nulo
        public string? Codigo { get; set; }  // Puede ser nulo
        public TimeOnly? HoraAsignada { get; set; }  // Puede ser nulo
        public string? Observacion { get; set; }  // Puede ser nulo
    }

}