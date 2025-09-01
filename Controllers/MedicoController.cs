using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Request;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("medico")]
public class MedicoController : ControllerBase
{

    private readonly IMedicoService _medicoService;
    public MedicoController(IMedicoService medicoService)
    {
        _medicoService = medicoService;
    }

    [HttpPost]
    [SwaggerResponse(200,"Creacion exitosa",typeof(MedicoCreateResponse))]
    public async Task<IActionResult> CrearMedico([FromBody] MedicoCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Datos incorrectos");
        }
        MedicoCreateResponse? response = await _medicoService.Crear(request);

        return Ok(response);
    }
    // [HttpPut("{id}")]
    // public async Task<IActionResult> ModificarMedico(int id, [FromBody] MedicoUpdateReq request)
    // {
    //     if (request == null)
    //     {
    //         return BadRequest("Datos incorrectos");
    //     }
    //     string? msg = await _medicoService.Modificar(id, request);

    //     return Ok(msg);
    // }
}
