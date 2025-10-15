using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{
    public class FormulaCCRes
    {
        public required int InsumoId { get; set; }
        public required string Porcentaje { get; set; }
        public required string Variable { get; set; }
        public required string FactorCorreccion { get; set; }
        public required string Dilucion { get; set; }
        public required string UnidadMedida { get; set; }
        public required string CantidadU { get; set; }
        public required string CantidadL { get; set; }
        public string? Practica { get; set; }
        public bool? CSP { get; set; }
    }

}