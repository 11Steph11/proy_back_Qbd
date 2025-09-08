namespace Proy_back_QBD.Dto.Response
{
    public class SedeCreateRes
    {
        public int? Id { get; set; }
    }
    public class SedeFindAllResponse
    {
        public int Id { get; set; }  // Puede ser nulo
        public required string Nombre { get; set; }
        public string? Direccion { get; set; }  // Puede ser nulo               
        public string? Encargado { get; set; }  // Puede ser nulo               
        public string? Telefono { get; set; }  // Puede ser nulo   
    }
}