using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proy_back_QBD.Services;

namespace Proy_back_QBD.Models
{

    public class Trabajadores
    {
        public string? Codigo { get; set; }  // Puede ser nulo        
        public string? CMP { get; set; }  // Puede ser nulo        
        public string? Datos { get; set; }  // Puede ser nulo        
        [Column("Hora_Entrada")]
        public TimeOnly? HoraEntrada { get; set; }  // Puede ser nulo
        [Column("Hora_Almuerzo")]
        public TimeOnly? HoraAlmuerzo { get; set; }  // Puede ser nulo
        [Column("Hora_Regreso")]
        public TimeOnly? HoraRegreso { get; set; }  // Puede ser nulo
        [Column("Hora_Salida")]
        public TimeOnly? HoraSalida { get; set; }  // Puede ser nulo
        [Column("Fecha_Creacion")]
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo
        public string? Usuario { get; set; }  // Puede ser nulo      
        [ForeignKey("IdSede")]
        public Sedes? Sedes { get; set; }  // Puede ser nulo       
        [Column("Id_Sede")]
        public int? IdSede { get; set; }  // Puede ser nulo       
        public string? Rol { get; set; }  // Puede ser nulo       

    }

}