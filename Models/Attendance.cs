using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{

    [Table("asistencias")]
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Puede ser nulo

        [Column("fecha_creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateOnly? FechaCreacion { get; set; }  // Puede ser nulo        
        [Column("tipo_horario")]
        public string? TipoHorario { get; set; }  // Puede ser nulo
        [Column("hora_asignada")]
        public TimeOnly? HoraAsignada { get; set; }  // Puede ser nulo
        [Column("hora_marcada")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeOnly? HoraMarcada { get; set; }  // Puede ser nulo
        [Column("tiempo_atraso")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan? TiempoAtraso { get; set; }  // Puede ser nulo
        [Column("tiempo_extra")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan? TiempoExtra { get; set; }  // Puede ser nulo
        public string? Observacion { get; set; }  // Puede ser nulo
        [ForeignKey("IdTrabajador")]
        public Employee? Trabajador { get; set; }  // Puede ser nulo
        [Column("id_trabajador")]
        public int? IdTrabajador { get; set; }  // Puede ser nulo
    }

}