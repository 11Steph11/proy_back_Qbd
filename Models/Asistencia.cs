using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    [Table("asistencias")]
    public class Asistencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }  // Puede ser nulo
        [Column("tipo")]
        public string? Tipo { get; set; }  // Puede ser nulo
        [Column("hora_asignada")]
        public TimeOnly? HoraAsignada { get; set; }  // Puede ser nulo
        [Column("hora_marcada")]
        public TimeOnly? HoraMarcada { get; set; }  // Puede ser nulo
        [Column("tiempo_atraso")]
        public TimeSpan? TiempoAtraso { get; set; }  // Puede ser nulo
        [Column("tiempo_extra")]
        public TimeSpan? TiempoExtra { get; set; }  // Puede ser nulo
        [Column("observacion")]
        public string? Observacion { get; set; }  // Puede ser nulo
        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo        
        [Column("creador")]
        public int? Creador { get; set; }  // Puede ser nulo        
        [Column("modificador")]
        public int? Modificador { get; set; }  // Puede ser nulo     
    }

}