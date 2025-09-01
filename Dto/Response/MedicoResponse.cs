using System.Text.Json.Serialization;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Dto.Response
{
    public class MedicoCreateResponse
    {
        public string? Msg { get; set; }  // Puede ser nulo      
        public Medico? MedicoRes { get; set;}
    }

}