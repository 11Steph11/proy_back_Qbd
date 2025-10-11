using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proy_back_QBD.Dto.Auxiliares
{
    public class FormulaRRes
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public string? Empaque { get; set; }  // Puede ser nulo
        public string? Procedimiento { get; set; }  // Puede ser nulo
        public string? Aspecto { get; set; }  // Puede ser nulo
        public string? Color { get; set; }  // Puede ser nulo
        public string? Olor { get; set; }  // Puede ser nulo
        public string? Ph { get; set; }  // Puede ser nulo
    }
}