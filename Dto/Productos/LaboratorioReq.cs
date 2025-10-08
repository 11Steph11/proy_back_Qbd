using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proy_back_QBD.Dto.Productos
{
    public class FormLabIns
    {

        public required LabCreReq Lab { get; set; }
        public required InsumsCreReq Ins { get; set; }

    }

    public class LabCreReq
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
    public class InsumsCreReq
    {
        public required int FormulaId { get; set; }
        public required int InsumoId { get; set; }
        public required string Porcentaje { get; set; }
        public required string? V { get; set; }
        public required string QU { get; set; }
        public required string QL { get; set; }
        public string? Pract { get; set; }
        public bool? CSP { get; set; }
    }
}