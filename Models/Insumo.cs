using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{

    [Table("insumo")]
    public class Insumo
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Column("descripcion")]
        public string? Descripcion { get; set; }
        [Column("um")]
        public string? UM { get; set; }
        [Column("fc")]
        public string? Fc { get; set; }
        [Column("dil")]
        public string? Dil { get; set; }
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
        [JsonIgnore]
        public Formula? Formula { get; set; }
        [Column("sedeId")]
        public int? SedeId { get; set; }  // Puede ser nulo
        [JsonIgnore]
        public Sede? Sede { get; set; }  // Puede ser nulo

    }

}