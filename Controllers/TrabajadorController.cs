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
[Route("trabajador")]
public class TrabajadorController : ControllerBase
{

    private readonly ITrabajadorService _trabajadorService;
    private readonly IMapper _mapper;

    public TrabajadorController(ITrabajadorService userService, IMapper mapper)
    {
        _trabajadorService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(UserLoginResponse))]
    public async Task<IActionResult> CrearTrabajador([FromBody] TrabajadorCreateRequest request)
    {
        Trabajador trabajador = _mapper.Map<Trabajador>(request);
        int? id = await _trabajadorService.RegistrarTrabajadorAsync(trabajador);
        UserLoginResponse response = new UserLoginResponse();
        response.Id = id;
        return Ok(response);
    }
}
