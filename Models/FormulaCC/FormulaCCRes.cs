using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{
    public class FormulaCCLabRes
    {
        public string CodigoPedido { get; set; }
        public string DniPaciente { get; set; }
        public string NombreCompleto { get; set; }
        public int EdadPaciente { get; set; }
        public string CMP { get; set; }
        public string NombreCompletoMed { get; set; }
        public string FormulaMagistral { get; set; }
        public string Lote { get; set; }
        public string NroReg { get; set; }
        public int Cantidad { get; set; }
        public decimal GPorMl { get; set; }
        public string UnidadMedida { get; set; }
        public decimal CostoTotal { get; set; }
        public List<FormulaCCLabSubRes> insumos { get; set; }
        public int? EmpaqueId { get; set; }
    }
    public class FormulaCCLabSubRes
    {

        public int InsumoId  { get; set; }
        public string Porcentaje { get; set; }
        public string Variable { get; set; }
        public string Practica { get; set; }
        public bool? CSP { get; set; }

    }

}