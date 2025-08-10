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
        Trabajador trabajador = _mapper.Map<Trabajador>(request);
        int? id = await _trabajadorService.Crear(trabajador);
        if (id == null)
        {
            return BadRequest("No se creó");
        }
        return Ok($"Usuario {id} ha sido Creado");
    }
    [HttpPut("{id}")]
    [SwaggerResponse(200, "Operación exitosa")]
    public async Task<IActionResult> ActualizarTrabajador(int id, [FromBody] TrabajadorUpdateReq? request)
    {
        if (request == null)
        {
            return BadRequest("Invalido");
        }
        int? idEmployee = await _trabajadorService.Actualizar(id, request);
        if (idEmployee == null)
        {
            return NotFound("No se encontró");
        }
        return Ok($"{idEmployee} ha sido actualizado");
    }
    [HttpDelete("{id}")]
    [SwaggerResponse(200, "Operación exitosa")]
    public async Task<IActionResult> EliminarTrabajador(int id)
    {
        int? idEmployee = await _trabajadorService.Eliminar(id);
        if (idEmployee == null)
        {
            return NotFound("No se encontró");
        }
        return Ok($"{idEmployee} ha sido eliminado");
    }
    [HttpGet("codigo/{codigo}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(TrabajadorRellenarByCodRes))]
    public async Task<IActionResult> RellenarPorCodigo(string codigo, [FromQuery] string tipoAsistencia)
    {
        if (tipoAsistencia == null)
        {
            return BadRequest("No envió tipo asistencia");
        }
        TrabajadorRellenarByCodRes? response = await _trabajadorService.Rellenar(codigo, tipoAsistencia);
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
        TrabajadorListarRes response = await _trabajadorService.Listar();
        if (response == null)
        {
            return BadRequest("No se encontró");
        }
        return Ok(response);
    }

    [HttpGet("Id/{id}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(TrabRellenarByIdRes))]
    public async Task<IActionResult> RellenarPorId(int id)
    {
        TrabRellenarByIdRes? response = await _trabajadorService.Rellenar(id);

        if (response == null)
        {
            return BadRequest("No se encontró");
        }
        
        return Ok(response);
    }
}
