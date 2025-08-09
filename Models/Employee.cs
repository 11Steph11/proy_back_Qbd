using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proy_back_QBD.Services;

namespace Proy_back_QBD.Models
{
    
    [Table("trabajadores")]
    public class Employee:User 
    {
        [Column("hora_entrada")]
        public TimeSpan? HoraEntrada{ get; set; }  // Puede ser nulo
        [Column("hora_almuerzo")]
        public TimeSpan? HoraAlmuerzo { get; set; }  // Puede ser nulo
        [Column("hora_regreso")]
        public TimeSpan? HoraRegreso { get; set; }  // Puede ser nulo
        [Column("hora_salida")]
        public TimeSpan? HoraSalida { get; set; }  // Puede ser nulo

        
    }

}