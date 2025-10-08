using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proy_back_QBD.Models
{
    [Table("empaques")]
    public class Empaque
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Column("descripcion")]
        public string? Descripcion { get; set; }
        [Column("funda")]
        public string? Funda { get; set; }
        [Column("caja")]
        public string? Caja { get; set; }
        [Column("etiqueta1")]
        public string? Etiqueta1 { get; set; }
        [Column("etiqueta2")]
        public string? Etiqueta2 { get; set; }
        [Column("tara")]
        public string? Tara { get; set; }
        [Column("fecha_modificacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaModificacion { get; set; }  // Puede ser nulo        
        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaCreacion { get; set; }  // Puede ser nulo        
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