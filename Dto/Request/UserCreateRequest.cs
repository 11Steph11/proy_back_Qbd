namespace Proy_back_QBD.Dto.Request
{
    public class UserCreateRequest
    {
        public string? Contrasena { get; set; }  // Puede ser nulo        
        public string? Nombres { get; set; }  // Puede ser nulo
        public string? ApellidoPaterno { get; set; }  // Puede ser nulo
        public string? ApellidoMaterno { get; set; }  // Puede ser nulo
        public int? IdTipo { get; set; }  // Puede ser nulo
        public int? IdCreador { get; set; }  // Puede ser nulo
        public string? DNI { get; set; }  // Puede ser nulo
        public string? CMP { get; set; }  // Puede ser nulo
        public int? IdSede { get; set; }  // Puede ser nulo

    }
}