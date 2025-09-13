using System.Text.Json.Serialization;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Dto.Request
{
    public class PedidoCreateReq
    {

        public required string Cuop { get; set; }
        public required string Periodo { get; set; }
        public string? Boleta { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }
        public string? ComprobanteElectronico { get; set; }
        public int CreadorId { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public List<FormulaCreateReq> Formulas { get; set; }
        public List<ProdTermCreateReq> ProductosTerminados { get; set; }
    }
    public class PedidoUpdateReq
    {
        public required string Cuop { get; set; }
        public required string Periodo { get; set; }
        public string? Boleta { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }
        public string? ComprobanteElectronico { get; set; }
        public int ModificadorId { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public List<FormulaUpdateReq> Formulas { get; set; }
        public List<ProdTermUpdateReq> ProductosTerminados { get; set; }
    }
}
