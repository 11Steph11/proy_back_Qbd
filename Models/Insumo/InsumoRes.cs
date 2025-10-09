using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proy_back_QBD.Dto.Productos
{
    public class InsumoLabRes
    {
        public int? Id { get; set; }
        public required string Descripcion { get; set; }
        public required string FactorCorreccion { get; set; }
        public required string Dilucion { get; set; }
        public required string UnidadMedida { get; set; }
    }
}