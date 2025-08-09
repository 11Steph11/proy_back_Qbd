using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{


    public class AsistenciaCreateReq
    {
        public string? TipoHorario { get; set; }  // Puede ser nulo
        public TimeOnly? HoraAsignada { get; set; }  // Puede ser nulo
        public string? Observacion { get; set; }  // Puede ser nulo
        public int? IdTrabajador { get; set; }  // Puede ser nulo                                
    }

}