using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{

    [Table("laboratorio")]
    public class Laboratorio
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Column("formulaR")]
        public string? FormulaR { get; set; }
        [Column("fecha_emision")]
        public DateOnly FechaEmision { get; set; }
        [Column("fecha_vcto")]
        public DateOnly FechaVcto { get; set; }
        [Column("elaborado")]
        public string? Elaborado { get; set; }
        [Column("autorizado")]
        public string? Autorizado { get; set; }
        [Column("procedimiento")]
        public string? Procedimiento { get; set; }
        [Column("cod_E")]
        public string? CodE { get; set; }
        [Column("cod_adicional")]
        public string? CodAdicional { get; set; }
        [Column("cod_termo")]
        public string? CodTermo { get; set; }
        [Column("canti_termo")]
        public int? CantiTermo { get; set; }
        [Column("etiqueta")]
        public string? Etiqueta { get; set; }
        [Column("etiqueta2")]
        public string? Etiqueta2 { get; set; }
        [Column("aspecto")]
        public string? Aspecto { get; set; }
        [Column("color")]
        public string? Color { get; set; }
        [Column("olor")]
        public string? Olor { get; set; }
        [Column("ph")]
        public string? Ph { get; set; }
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
        public Formula? Formula { get; set; }        

    }

}