using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{

    public class Asistencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Puede ser nulo
        public string? Tipo { get; set; }  // Puede ser nulo
        public string? Codigo { get; set; }  // Puede ser nulo
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]        
        [Column("hora_asignada")]
        public TimeOnly? HoraAsignada { get; set; }  // Puede ser nulo
        [Column("hora_marcada")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeOnly? HoraMarcada { get; set; }  // Puede ser nulo
        [Column("Tiempo_Atraso")]
        public TimeOnly? TiempoAtraso { get; set; }  // Puede ser nulo
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Tiempo_Extra")]
        public TimeOnly? TiempoExtra { get; set; }  // Puede ser nulo
        public string? Observacion { get; set; }  // Puede ser nulo
        [Column("Fecha_Creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateOnly? FechaCreacion { get; set; }  // Puede ser nulo        
        public string? Usuario { get; set; }  // Puede ser nulo        
    }

}