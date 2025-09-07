using System.Text.Json.Serialization;

namespace Proy_back_QBD.Dto.Request
{
    public class PacienteCreateReq
    {

        public string? Apoderado { get; set; }
        public string? DniApoderado { get; set; }
        public int? CreadorId { get; set; }        
        public PersonaCreateReq? PersonaFk { get; set; }
        public bool? CondicionFecha { get; set; }
    }
    public class PacienteUpdateReq : PacienteCreateReq
    {
        [JsonIgnore]
        public PersonaCreateReq? PersonaFk { get; set; }  // Puede ser nulo    
        public PersonaUpdateReq? PersonaUReq { get; set; }  // Puede ser nulo   
        [JsonIgnore]
        public int? CreadorId { get; set; }
        public int? ModificadorId { get; set; }
    }
}
