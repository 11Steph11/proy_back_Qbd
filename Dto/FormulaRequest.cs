using System.Text.Json.Serialization;

namespace Proy_back_QBD.Dto.Request
{
    public class FormulaCreateReq
    {
        public decimal? Costo { get; set; }                    // Costo del pedido
        public int? Cantidad { get; set; }                     // Cantidad de unidades solicitadas
        public string? FormulaMagistral { get; set; }          // Descripción de la fórmula magistral
        public string? FormulaFarmacia { get; set; }           // Descripción de la fórmula de farmacia
        public decimal? GPorMl { get; set; }                   // g/ml (gramos por mililitro)
        public string? UnidadMedida { get; set; }              // Unidad de medida (ej. "ml", "mg", "g", etc.)
        public string? Lote { get; set; }                      // Lote del producto
        public string? Diagnostico { get; set; }               // Diagnóstico relacionado al pedido
        public string? ZonaAplicada { get; set; }              // Zona donde se aplica el tratamiento (si aplica)
        public string? Estado { get; set; }                    // Estado del pedido (pendiente, procesado, entregado, etc.)
        public bool? Reportado { get; set; }                   // Si ha sido reportado o no (valor booleano)
        public int CreadorId { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
    public class FormulaUpdateReq : FormulaCreateReq
    {
        [JsonIgnore]
        public int? CreadorId { get; set; }
    }
}
