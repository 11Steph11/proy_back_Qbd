using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Response
{
    using System.ComponentModel.DataAnnotations.Schema;
    using global::Proy_back_QBD.Models;

    namespace Proy_back_QBD.Dto.Response
    {

        public class CobroByIdRes
        {
            public string? NombreCompleto { get; set; }
            public TimeOnly? Almuerzo { get; set; }
            public TimeOnly? Entrada { get; set; }
            public TimeOnly? Regreso { get; set; }
            public TimeOnly? Salida { get; set; }            
        }
        public class CobroCreateRes
        {
            public string? Msg { get; set; }
            public Cobro? Cobro { get; set; }            
        }
    }
}