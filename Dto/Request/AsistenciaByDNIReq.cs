using System.ComponentModel.DataAnnotations;

namespace Proy_back_QBD.Dto.Request
{
    public class AsistenciaByDNIReq
    {
        [Required]
        public string? DNI { get; set; }
        [Required]
        public int Año { get; set; }
        [Required]
        public int Mes { get; set; }
    }
}