using System.Text.Json.Serialization;

namespace Proy_back_QBD.Dto.Request
{
    public class MedicoCreateReq
    {
        public int? EspecialidadId { get; set; }  // Puede ser nulo      
        public string? NumeroEspecialidad { get; set; }  // Puede ser nulo      
        public int? CreadorId { get; set; }
        public PersonaCreateReq? PersonaCReq { get; set; }  // Puede ser nulo    
        public string? Cmp { get; set; }  // Puede ser nulo        
    }
    public class MedicoUpdateReq : MedicoCreateReq
    {
        [JsonIgnore]
        public int? CreadorId { get; set; }
        [JsonIgnore]
        public PersonaCreateReq? PersonaCReq { get; set; }  // Puede ser nulo    
        public PersonaUpdateReq? PersonaUReq { get; set; }  // Puede ser nulo    
        public int? ModificadorId { get; set; }
    }
}