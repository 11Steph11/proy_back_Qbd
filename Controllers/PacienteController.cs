using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("paciente")]
public class PacienteController : ControllerBase
{

    private readonly IPacienteService _pacienteService;

    public PacienteController( IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    [HttpPost()]
    [SwaggerResponse(200, "Operación exitosa", typeof(int))]
    public async Task<IActionResult> CrearPaciente([FromBody] PacienteCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }
        string? msg = await _pacienteService.Crear(request);
        return Ok(msg);
    }
}
