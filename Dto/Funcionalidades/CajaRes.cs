using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Response
{
    using System.ComponentModel.DataAnnotations.Schema;
    using global::Proy_back_QBD.Models;



    public class CajaFindAllRes
    {
        public List<MovimientosEfectivo>? Movimientos { get; set; }
        public RecaudacionDelDia? RecaudacionDelDia { get; set; }
        public RPagosDelDia? RPagosDelDia { get; set; }
        public RPagosAnteriores? RPagosAnteriores { get; set; }
    }
    public class MovimientosEfectivo
    {
        public string? CUO_R { get; set; }
        public string? CUO_C { get; set; }
        public DateOnly? Fecha { get; set; }
        public string? Dni { get; set; }
        public string? Paciente { get; set; }
        public DateOnly? FechaPedido { get; set; }
        public string? Modalidad { get; set; }
        public decimal? Importe { get; set; }
        public TimeOnly? Hora { get; set; }
        public string? Turno { get; set; }
        public string? BolFac { get; set; }
    }
    public class RecaudacionDelDia
    {
        public string? Total { get; set; }
        public string? Efectivo { get; set; }
        public string? Electronico { get; set; }
    }
    public class RPagosDelDia
    {
        public string? Total { get; set; }
        public string? Efectivo { get; set; }
        public string? Electronico { get; set; }
    }
    public class RPagosAnteriores
    {
        public string? Total { get; set; }
        public string? Efectivo { get; set; }
        public string? Electronico { get; set; }
    }
    public class BQPagosDelDia
    {
        public string? Total { get; set; }
        public string? Efectivo { get; set; }
        public string? Electronico { get; set; }
    }
    public class Ventas
    {
        public string? Total { get; set; }
        public string? Adelantos { get; set; }
        public string? Electronico { get; set; }
    }


}