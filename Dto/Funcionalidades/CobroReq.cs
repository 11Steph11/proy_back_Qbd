using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Request
{
    public class CobroCreateReq
    {
        public int? PedidoId { get; set; }
        public string? Periodo { get; set; }
        public string? Modalidad { get; set; }
        public string? Turno { get; set; }
        public decimal? Importe { get; set; }
    }
    public class CobroByIdReq
    {
        [Required]
        public int Año { get; set; }
        [Required]
        public int Mes { get; set; }
    }
}