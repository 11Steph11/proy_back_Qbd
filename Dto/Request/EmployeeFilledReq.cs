using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto
{


    public class EmployeeFilledReq
    {
        public string? Codigo { get; set; }  // Puede ser nulo                   
        public string? TipoAsistencia { get; set; }  // Puede ser nulo                   
    }

}