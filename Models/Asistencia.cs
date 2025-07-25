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
        public int? Id { get; set; }  // Puede ser nulo

        [Column("fecha_creacion")]
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo        
        [Column("tipo_horario")]
        public string? TipoHorario { get; set; }  // Puede ser nulo
        [Column("hora_asignada")]
        public TimeSpan? HoraAsignada { get; set; }  // Puede ser nulo
        [Column("hora_marcada")]
        public TimeSpan? HoraMarcada { get; set; }  // Puede ser nulo
        [Column("tiempo_atraso")]
        public TimeSpan? TiempoAtraso { get; set; }  // Puede ser nulo
        [Column("tiempo_extra")]
        public TimeSpan? TiempoExtra { get; set; }  // Puede ser nulo
        public string? Observacion { get; set; }  // Puede ser nulo
        [ForeignKey("IdTrabajador")]
        public Trabajador? Trabajador { get; set; }  // Puede ser nulo
        [Column("id_trabajador")]
        public int? IdTrabajador { get; set; }  // Puede ser nulo
    }

}