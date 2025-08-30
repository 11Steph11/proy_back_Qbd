namespace Proy_back_QBD.Dto.Request
{
        public class MedicoCreateReq
    {
        public string? Cmp { get; set; }  // Puede ser nulo        
        public string? Datos { get; set; }  // Puede ser nulo        
        public string? Especialidad { get; set; }  // Puede ser nulo      
        public string? NumeroEspecialidad { get; set; }  // Puede ser nulo      
        public string? Usuario { get; set; }  // Puede ser nulo       
    }
    public class MedicoUpdateReq : MedicoCreateReq
    {

    }
}