using Proy_back_QBD.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using Proy_back_QBD.Models;
namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/sede")]
public class SedeController : ControllerBase
{

    private readonly ISedeService _sedeService;
    private readonly IMapper _mapper;

    public SedeController(ISedeService userService, IMapper mapper)
    {
        _sedeService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(SedeCreateRes))]
    public async Task<IActionResult> CrearSede([FromBody] SedeCreateReq request)
    {
        Sede sede = _mapper.Map<Sede>(request);
        Sede? response = await _sedeService.RegistrarSede(sede);
        return Ok(response);
    }
}
