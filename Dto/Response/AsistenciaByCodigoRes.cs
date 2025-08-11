using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto.Response
{
    public class FechaConHoras
    {
        public int? Codigo { get; set; }
        public int? Numero { get; set; }
        public string? Dia { get; set; }
        [Column("Hora_Entrada")]
        public string? HoraEntrada { get; set; }
        [Column("Hora_Almuerzo")]
        public string? HoraAlmuerzo { get; set; }
        [Column("Hora_Regreso")]
        public string? HoraRegreso { get; set; }
        [Column("Hora_Salida")]
        public string? HoraSalida { get; set; }
    }
    public class AsistenciaByCodigoRes
    {
        public string? NombreCompleto { get; set; }
        public TimeOnly? Almuerzo { get; set; }
        public TimeOnly? Entrada { get; set; }
        public TimeOnly? Regreso { get; set; }
        public TimeOnly? Salida { get; set; }
        public List<FechaConHoras>? Asistencias { get; set; }
    }
}