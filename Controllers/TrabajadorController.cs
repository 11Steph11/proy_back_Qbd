using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using Proy_back_QBD.Dto;

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
    [SwaggerResponse(200, "Operación exitosa", typeof(UsuarioLoginRes))]
    public async Task<IActionResult> CrearTrabajador([FromBody] TrabajadorCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Invalido");
        }
        string? codigo = await _trabajadorService.Crear(request);
        if (codigo == null)
        {
            return BadRequest("No se creó");
        }
        return Ok($"Usuario {codigo} ha sido Creado");
    }
    [HttpPut("codigo/{codigo}")]
    [SwaggerResponse(200, "Operación exitosa")]
    public async Task<IActionResult> ActualizarTrabajador(string codigo, [FromBody] TrabajadorUpdateReq? request)
    {
        if (request == null)
        {
            return BadRequest("Invalido");
        }
        string? idEmployee = await _trabajadorService.Actualizar(codigo, request);
        if (idEmployee == null)
        {
            return NotFound("No se encontró");
        }
        return Ok($"{idEmployee} ha sido actualizado");
    }
    [HttpDelete("codigo/{codigo}")]
    [SwaggerResponse(200, "Operación exitosa")]
    public async Task<IActionResult> EliminarTrabajador(string codigo)
    {
        string? idEmployee = await _trabajadorService.Eliminar(codigo);
        if (idEmployee == null)
        {
            return NotFound("No se encontró");
        }
        return Ok($"{idEmployee} ha sido eliminado");
    }
    [HttpGet("fill/asist/{codigo}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(TrabajadorRellenarByCodAsistRes))]
    public async Task<IActionResult> RellenarPorCodigo(string codigo, [FromQuery] string tipoAsistencia)
    {
        if (tipoAsistencia == null)
        {
            return BadRequest("No envió tipo asistencia");
        }
        TrabajadorRellenarByCodAsistRes? response = await _trabajadorService.Rellenar(codigo, tipoAsistencia);
        if (response == null)
        {
            return BadRequest("No se encontró");
        }
        return Ok(response);
    }

    [HttpGet()]
    [SwaggerResponse(200, "Operación exitosa", typeof(TrabajadorListarRes))]
    public async Task<IActionResult> ListarTrabajadores()
    {
        TrabajadorListarRes? response = await _trabajadorService.Listar();
        if (response == null)
        {
            return BadRequest("No se encontró");
        }
        return Ok(response);
    }

    [HttpGet("fill/gest/{codigo}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(TrabRellenarByCodGestRes))]
    public async Task<IActionResult> RellenarPorId(string codigo)
    {
        TrabRellenarByCodGestRes? response = await _trabajadorService.Rellenar(codigo);

        if (response == null)
        {
            return BadRequest("No se encontró");
        }
        
        return Ok(response);
    }
}
