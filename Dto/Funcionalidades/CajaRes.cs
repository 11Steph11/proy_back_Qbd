using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Response
{
    using System.ComponentModel.DataAnnotations.Schema;
    using global::Proy_back_QBD.Models;



        public class CajaFindAllRes
        {
            public string? CUO_R { get; set; }
            public string? CUO_C { get; set; }
            public DateOnly? Fecha { get; set; }
            public string? Dni { get; set; }
            public string? Paciente { get; set; }            
            public DateOnly? FechaPedido { get; set; }
            public string? Modalidad { get; set; }
            public string? Importe { get; set; }
            public TimeOnly? Hora { get; set; }
            public string? Turno { get; set; }
            public string? BolFac { get; set; }
        }
    
}