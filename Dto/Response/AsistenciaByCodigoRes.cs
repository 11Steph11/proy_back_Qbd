using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto.Response
{
    public class FechaConHoras
    {
        [Column("id_trabajador")]
        public int? IdTrabajador { get; set; }
        [Column("numero")]
        public int? Numero { get; set; }
        [Column("dia")]
        public string? Dia { get; set; }
        [Column("hora_entrada")]
        public string? HoraEntrada { get; set; }
        [Column("hora_almuerzo")]
        public string? HoraAlmuerzo { get; set; }
        [Column("hora_regreso")]
        public string? HoraRegreso { get; set; }
        [Column("hora_salida")]
        public string? HoraSalida { get; set; }
    }
    public class AsistenciaByCodigoRes
    {
        public string? NombreCompleto { get; set; }
        public TimeSpan? Entrada { get; set; }
        public TimeSpan? Almuerzo { get; set; }
        public TimeSpan? Regreso { get; set; }
        public TimeSpan? Salida { get; set; }
        public List<FechaConHoras>? Asistencias { get; set; }
    }
}