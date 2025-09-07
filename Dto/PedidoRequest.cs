using System.Text.Json.Serialization;

namespace Proy_back_QBD.Dto.Request
{
    public class PedidoCreateReq
    {

        public string? Cuop { get; set; }
        public string? Periodo { get; set; }
        public string? Boleta { get; set; }
        public int? PacienteId { get; set; }
        public int? MedicoId { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }
        public string? ComprobanteElectronico { get; set; }
        public int? Creador { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
    public class PedidoUpdateReq : PedidoCreateReq
    {
        [JsonIgnore]
        public int? Creador { get; set; }
    }
}
