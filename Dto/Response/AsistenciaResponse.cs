using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto.Response
{
    public class AsistenciaCreateRes
    {
        public TimeOnly? HoraMarcada { get; set; }
        public TimeSpan? Diferencia { get; set; }
    }

     public class FechaConHoras
    {
        public string? Dia { get; set; }
        [Column("Hora_Entrada")]
        public string? HoraEntrada { get; set; }
        [Column("Hora_Salida")]
        public string? HoraSalida { get; set; }
    }
    public class AsistenciaByIdRes
    {
        public string? NombreCompleto { get; set; }
        public TimeOnly? Almuerzo { get; set; }
        public TimeOnly? Entrada { get; set; }
        public TimeOnly? Regreso { get; set; }
        public TimeOnly? Salida { get; set; }
        public List<FechaConHoras>? Asistencias { get; set; }
    }
}