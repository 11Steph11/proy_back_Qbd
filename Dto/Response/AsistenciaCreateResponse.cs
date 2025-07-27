namespace Proy_back_QBD.Dto.Response
{
    public class AsistenciaCreateResponse
    {
        public int? Id { get; set; }
        public TimeOnly? HoraMarcada { get; set; }
        public TimeSpan? Diferencia { get; set; }
    }
}