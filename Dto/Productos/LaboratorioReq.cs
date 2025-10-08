using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proy_back_QBD.Dto.Productos
{
    public class FormLabIns
    {

        public required Lab Lab { get; set; }
        public required Ins Ins { get; set; }

    }

    public class Lab
    {
        public string? FormulaR { get; set; }
        public DateOnly FechaEmision { get; set; }
        public DateOnly FechaVcto { get; set; }
        public string? Elaborado { get; set; }
        public string? Autorizado { get; set; }
        public string? Procedimiento { get; set; }
        public string? CodE { get; set; }
        public string? CodAdicional { get; set; }
        public string? CodTermo { get; set; }
        public int? CantiTermo { get; set; }
        public string? Etiqueta { get; set; }
        public string? Etiqueta2 { get; set; }
        public string? Aspecto { get; set; }
        public string? Color { get; set; }
        public string? Olor { get; set; }
        public string? Ph { get; set; }
        public int CreadorId { get; set; }
    }
    public class Ins
    {

    }
}