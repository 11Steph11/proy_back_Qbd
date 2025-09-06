using System.Text.Json.Serialization;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Dto.Response
{
    public class PedidoFindAllResponse
    {
        public string? Cuo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? Apoderado { get; set; }
        public string? DniApoderado { get; set; }
    }
    public class PedidoCreateResponse
    {
        public string? Msg { get; set; }  // Puede ser nulo      
        public Pedido? PedidoRes { get; set; }
    }
    public class PedidoUpdateResponse
    {
        public string? Msg { get; set; }  // Puede ser nulo      
        public Pedido? PedidoRes { get; set; }
    }

    public class PedidoFindIdResponse
    {
        public int? Id { get; set; }  // Puede ser nulo
        public int? Apoderado { get; set; }
        public string? DniApoderado { get; set; }
        public PersonaRes? PersonaFk { get; set; }  // Puede ser nulo
        public bool? CondicionFecha { get; set; }
    }
    
}