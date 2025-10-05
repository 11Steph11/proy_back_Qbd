using System.ComponentModel.DataAnnotations.Schema;

namespace Proy_back_QBD.Dto.Response
{
    public class GeneralReq
    {
        public int? Meta { get; set; }
        public string? MsgWsp { get; set; }
        public string? MsgCumple { get; set; }
        public string? MsgGpt { get; set; }
    }

  
}