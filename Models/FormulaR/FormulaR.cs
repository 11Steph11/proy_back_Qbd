using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proy_back_QBD.Models
{
    [Table("formulasR")]
    public class FormulaR
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }  // Puede ser nulo
        [Column("descripcion")]
        public required string Descripcion { get; set; }  // Puede ser nulo
        [Column("empaque")]
        public string? Empaque { get; set; }  // Puede ser nulo
        [Column("procedimiento")]
        public string? Procedimiento { get; set; }  // Puede ser nulo
        [Column("aspecto")]
        public string? Aspecto { get; set; }  // Puede ser nulo
        [Column("color")]
        public string? Color { get; set; }  // Puede ser nulo
        [Column("olor")]
        public string? Olor { get; set; }  // Puede ser nulo
        [Column("ph")]
        public string? Ph { get; set; }  // Puede ser nulo
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
        [Column("sedeId")]
        public int? SedeId { get; set; }  // Puede ser nulo
        [JsonIgnore]
        public Sede? Sede { get; set; }  // Puede ser nulo
        [JsonIgnore]
        public List<InsumoR>? InsumoR { get; set; }  // Puede ser nulo
    }
}