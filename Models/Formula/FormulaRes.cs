using System.Text.Json.Serialization;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Dto.Response
{
    public class FormulaFindAllResponse
    {
        public string? Cuo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? Dni { get; set; }
        public string? Paciente { get; set; }
        public string? Celular { get; set; }
        public string? Medico { get; set; }
        public string? Usuario { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string? BolFaC { get; set; }
    }
    public class FormulasByPedido
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public decimal? Costo { get; set; }                    // Costo del pedido
        public int? Cantidad { get; set; }                     // Cantidad de unidades solicitadas
        public string? FormulaMagistral { get; set; }          // Descripción de la fórmula magistral
        public string? FormaFarmaceutica { get; set; }           // Descripción de la fórmula de farmacia
        public decimal? GPorMl { get; set; }                   // g/ml (gramos por mililitro)
        public string? UnidadMedida { get; set; }              // Unidad de medida (ej. "ml", "mg", "g", etc.)
        public string? Lote { get; set; }                      // Lote del producto
        public string? Diagnostico { get; set; }               // Diagnóstico relacionado al pedido
        public string? ZonaAplicacion { get; set; }              // Zona donde se aplica el tratamiento (si aplica)
        public string? Estado { get; set; }
        public string? Reportado { get; set; }                   // Si ha sido reportado o no (valor booleano)
    }
    public class FormulaCreateResponse
    {
        public string? Msg { get; set; }  // Puede ser nulo      
        public Formula? FormulaRes { get; set; }
    }
    public class FormulaUpdateResponse
    {
        public string? Msg { get; set; }  // Puede ser nulo      
        public Formula? FormulaRes { get; set; }
    }

    public class FormulaFindIdResponse
    {
        public int? Id { get; set; }  // Puede ser nulo
        public int? Apoderado { get; set; }
        public string? DniApoderado { get; set; }
        public PersonaRes? PersonaFk { get; set; }  // Puede ser nulo
        public bool? CondicionFecha { get; set; }
    }
    public class RecetaRes
    {
        public string? Medico { get; set; }  // Puede ser nulo
        public DateOnly? Fecha { get; set; }
        public string? Prescripcion { get; set; }
        public string? Gram { get; set; }  // Puede ser nulo
        public int? Cant { get; set; }
        public string? Mili { get; set; }
        public string? Gotas { get; set; }
        public string? Observacion { get; set; }
        public decimal? Precio { get; set; }
        public string? Tipo { get; set; }
    }

}
