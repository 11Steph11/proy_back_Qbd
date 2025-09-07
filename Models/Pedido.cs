using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{

    [Table("pedidos")]
    public class Pedido
    {
        [Column("periodo")]
        public string? Periodo { get; set; }
        [Column("boleta")]
        public string? Boleta { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente? PacienteFk { get; set; }
        [Column("paciente_id")]
        public int? PacienteId { get; set; }
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
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo               
        [Column("fecha_modificacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? FechaModificacion { get; set; }  // Puede ser nulo        
        [Column("creador")]
        public int? Creador { get; set; }  // Puede ser nulo               
        [Column("modificador")]
        public int? Modificador { get; set; }  // Puede ser nulo               
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }  // Puede ser nulo
        [Column("fecha_entrega")]
        public DateTime? FechaEntrega { get; set; }  // Puede ser nulo                    
        [ForeignKey("MedicoId")]
        public Medico? MedicoFk { get; set; }

        [Column("medico_id")]
        public int? MedicoId { get; set; }
        public List<Formula>? Formulas { get; set; }
    }

}