using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/paciente")]
public class PacienteController : ControllerBase
{

    private readonly IPacienteService _pacienteService;

    public PacienteController(IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    [HttpPost()]
    [SwaggerResponse(200, "Operación exitosa", typeof(PacienteCreateResponse))]
    public async Task<IActionResult> CrearPaciente([FromBody] PacienteCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }
        PacienteCreateResponse? response = await _pacienteService.Crear(request);
        return Ok(response);
    }
    [HttpPut("{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(PacienteUpdateReq))]
    public async Task<IActionResult> ActualizarMedico(int id, [FromBody] PacienteUpdateReq request)
    {
        if (request == null)
        {
            return BadRequest("Datos incorrectos");
        }
        PacienteUpdateResponse? response = await _pacienteService.Actualizar(id, request);

        return Ok(response);
    }
}
