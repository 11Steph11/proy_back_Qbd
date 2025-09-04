using System.Text.Json.Serialization;

namespace Proy_back_QBD.Dto.Request
{
    public class MedicoCreateReq
    {
        public int? EspecialidadId { get; set; }  // Puede ser nulo      
        public string? NumeroEspecialidad { get; set; }  // Puede ser nulo      
        public int? Creador { get; set; }  // Puede ser nulo    
        public PersonaCreateReq? PersonaCReq { get; set; }  // Puede ser nulo    
        public int? Modificador { get; set; }  // Puede ser nulo       
        public string? Cmp { get; set; }  // Puede ser nulo        
    }
    public class MedicoUpdateReq : MedicoCreateReq
    {
        [JsonIgnore]
        public int? Creador { get; set; }
        [JsonIgnore]
        public PersonaCreateReq? PersonaCReq { get; set; }  // Puede ser nulo    
        public PersonaUpdateReq? PersonaUReq { get; set; }  // Puede ser nulo    
    }
}