using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Models
{
    [Table("Pacientes")]
    public class Pacientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }  // Puede ser nulo
        [Column("Nombres_Apellidos")]
        public string? Datos { get; set; }
        public string? Direccion { get; set; }
        [Column("Fecha_Ncto")]
        public DateOnly? FechaNcto { get; set; }
        public string? DNI { get; set; }
        [Column("Telefono")]
        public string? Celular { get; set; }
        [Column("DniA")]
        public string? DniApoderado { get; set; }
        public string? Apoderado { get; set; }
        [Column("Fecha_Creacion")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? FechaCreacion { get; set; }
        public string? Usuario { get; set; }
        [Column("Condicion_Fecha")]
        public string? Aproximado { get; set; }
    }

}