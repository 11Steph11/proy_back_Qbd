using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{

    [Table("formulasCC")]
    public class FormulaCC
    {
        [Column("formula_id")]
        public int? FormulaId { get; set; }
        [JsonIgnore]
        public Formula? Formula { get; set; }
        [Column("insumo_id")]
        public required int InsumoId { get; set; }
        [JsonIgnore]
        public required Insumo Insumo { get; set; }
        [Column("porcentaje")]
        public required string Porcentaje { get; set; }
        [Column("variable")]
        public required string Variable { get; set; }
        [Column("cantidad_U")]
        public required string CantidadU { get; set; }
        [Column("cantidad_L")]
        public required string CantidadL { get; set; }
        [Column("practica")]
        public string? Practica { get; set; }
        [Column("csp")]
        public bool? CSP { get; set; }
        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaCreacion { get; set; }           // Fecha de creación del pedido
        [Column("fecha_modificacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaModificacion { get; set; }       // Fecha de la última modificación del pedido
        [Column("creador_id")]
        public int CreadorId { get; set; }
        [JsonIgnore]
        public Usuario? Creador { get; set; }
        [Column("modificador_id")]
        public int ModificadorId { get; set; }
        [JsonIgnore]
        public Usuario? Modificador { get; set; }        
    }

}