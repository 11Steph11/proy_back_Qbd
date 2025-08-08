using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{


    public class EmployeeFilledReq
    {
        public string? Codigo { get; set; }  // Puede ser nulo                   
    }

}