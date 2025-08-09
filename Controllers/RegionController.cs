using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("sede")]
public class RegionController : ControllerBase
{

    private readonly IRegionService _sedeService;
    private readonly IMapper _mapper;

    public RegionController(IRegionService userService, IMapper mapper)
    {
        _sedeService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(RegionCreateRes))]
    public async Task<IActionResult> CrearSede([FromBody] RegionCreateRequest request)
    {
        Sede sede = _mapper.Map<Sede>(request);
        int? id = await _sedeService.RegistrarSedeAsync(sede);
        RegionCreateRes response = new RegionCreateRes();
        response.Id = id;
        return Ok(response);
    }
}
