using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{

    public class Pacientes
    {
        public string? Numero { get; set; } 
        [Column("Nombres_Apellidos")]
        public string? NombresApellidos { get; set; } 
        public string? Direccion { get; set; } 
        [Column("Fecha_Ncto")]
        public DateOnly? FechaNacimiento { get; set; } 
        public string? Telefono { get; set; } 
        [Column("DniA")]
        public string? DniApoderado { get; set; }  
        public string? Apoderado { get; set; } 
        [Column("Fecha_Creacion")]
        public DateTime? FechaCreacion { get; set; }  
        public string? Usuario { get; set; }  
        [Column("Condicion_Fecha")]
        public string? CondicionFecha { get; set; }  
    }

}