using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{

    [Table("pedidos")]
    public class Pedido
    {
        [Column("periodo")]
        public string? Periodo { get; set; }
        [Column("boleta")]
        public string? Boleta { get; set; }
        [Column("paciente_id")]
        public int? PacienteId { get; set; }
        [JsonIgnore]
        public Paciente? Paciente { get; set; }
        [Column("img1")]
        public string? Img1 { get; set; }
        [Column("img2")]
        public string? Img2 { get; set; }
        [Column("img3")]
        public string? Img3 { get; set; }
        [Column("comprobante_electronico")]
        public string? ComprobanteElectronico { get; set; }
        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaCreacion { get; set; }  // Puede ser nulo               
        [Column("fecha_modificacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaModificacion { get; set; }  // Puede ser nulo        
        [Column("creador_id")]
        public int CreadorId { get; set; }
        [JsonIgnore]
        public Usuario? Creador { get; set; }
        [Column("modificador_id")]
        public int ModificadorId { get; set; }
        [JsonIgnore]
        public Usuario? Modificador { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }  // Puede ser nulo
        [Column("fecha_entrega")]
        public DateTime? FechaEntrega { get; set; }  // Puede ser nulo                    
        [Column("medico_id")]
        public int MedicoId { get; set; }
        [JsonIgnore]
        public Medico? Medico { get; set; }
        public List<Formula>? Formulas { get; set; }
        public List<ProdTerm>? ProdTerms { get; set; }
    }

}