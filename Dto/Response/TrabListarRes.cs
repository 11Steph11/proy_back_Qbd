namespace Proy_back_QBD.Dto.Response
{
    public class TrabListarRes
    {
        public int? Total { get; set; }
        public List<ListaTrabajadores>? ListaTrabajadores {get; set;}
    }
    public class ListaTrabajadores
    {
        public string? Codigo { get; set; }
        public int? Id { get; set; }
        public string? Descripcion { get; set; }
    }
}