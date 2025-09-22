using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Request
{

    public class CajaFindAllReq
    {
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFinal { get; set; }
    }
}