using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("medico")]
public class MedicoController : ControllerBase
{

    private readonly IMedicoService _medicoService;
    private readonly IMapper _mapper;

    public MedicoController(IMedicoService medicoService)
    {
        _medicoService = medicoService;
    }

    [HttpPost]
    public async Task<IActionResult> CrearMedico([FromBody] MedicoCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Datos incorrectos");
        }
        string? msg = await _medicoService.CrearMedico(request);

        return Ok(msg);
    }

}
