using System.ComponentModel.DataAnnotations;

namespace Proy_back_QBD.Dto.Request
{
    public class AsistenciaByCodigoReq
    {
        [Required]
        public int Año { get; set; }
        [Required]
        public int Mes { get; set; }
    }
}