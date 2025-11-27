using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{
    public class FormulaCCUpdReq
    {
        
        public required List<ListInsumUpdReq> Insumos { get; set; }
        public required string Procedimiento { get; set; }

    }
    public class ListInsumUpdReq
    {
        
        public required int InsumoId { get; set; }
        public required string Porcentaje { get; set; }
        public required string? Variable { get; set; }
        public required string CantidadU { get; set; }
        public required string CantidadL { get; set; }
        public string? Practica { get; set; }
        public bool? CSP { get; set; }
        public int CreadorId { get; set; }
        public int ModificadorId { get; set; }
    }

}