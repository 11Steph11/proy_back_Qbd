using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Dto.Empaque
{
    public class EmpaqueCreateReq
    {
        public string? Descripcion { get; set; }
        public string? Funda { get; set; }
        public string? Caja { get; set; }
        public string? Etiqueta1 { get; set; }
        public string? Etiqueta2 { get; set; }
        public string? Tara { get; set; }
        public int CreadorId { get; set; }
        public int SedeId { get; set; }
    }
    public class EmpaqueUpdateReq
    {
        public string? Descripcion { get; set; }
        public string? Funda { get; set; }
        public string? Caja { get; set; }
        public string? Etiqueta1 { get; set; }
        public string? Etiqueta2 { get; set; }
        public string? Tara { get; set; }
        public int ModificadorId { get; set; }
    }
}