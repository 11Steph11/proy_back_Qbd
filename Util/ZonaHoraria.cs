using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proy_back_QBD.Util
{
    public class ZonaHoraria
    {        
        public static DateTime AjustarZona(DateTime fechaInicial)
        {
            TimeZoneInfo ajusteHorario = TimeZoneInfo.FindSystemTimeZoneById("America/Lima");
            DateTime fechaAjustada = TimeZoneInfo.ConvertTime(fechaInicial, ajusteHorario);
            return fechaAjustada;
        }
    }
}