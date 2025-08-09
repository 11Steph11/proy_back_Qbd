namespace Proy_back_QBD.Dto.Response
{
    public class AsistenciaCreateRes
    {
        public int? Id { get; set; }
        public TimeOnly? HoraMarcada { get; set; }
        public TimeSpan? Diferencia { get; set; }
    }
}