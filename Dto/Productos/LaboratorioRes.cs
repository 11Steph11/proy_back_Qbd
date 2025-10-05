using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proy_back_QBD.Dto.Productos
{
    public class PedidoLab
    {
        public string? Cuo { get; set; }                          // ID único del pedido
        public DateTime? Fecha { get; set; }                    // Costo del pedido
        public string? DNI { get; set; }                     // Cantidad de unidades solicitadas
        public string? Paciente { get; set; }                   // g/ml (gramos por mililitro)
        public string? FormulaMagistral { get; set; }              // Zona donde se aplica el tratamiento (si aplica)
        public string? Registro { get; set; }               // Diagnóstico relacionado al pedido
        public string? Elaborado { get; set; }
    }
}