using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    [Table("Medicos")]
    public class Medicos
   {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }  // Puede ser nulo        
        public string? Cmp { get; set; }
        public string? Datos { get; set; }
        public string? Especialidad { get; set; }
        [Column("Numero_Especialidad")]
        public string? NumeroEspecialidad { get; set; }
        [Column("Fecha_Creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? FechaCreacion { get; set; }
        public string? Usuario { get; set; }
       
    }

}