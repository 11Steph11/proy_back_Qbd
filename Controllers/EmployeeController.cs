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
public class EmployeeController : ControllerBase
{

    private readonly IEmployeeService _employeeService;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeService userService, IMapper mapper)
    {
        _employeeService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(UserLoginRes))]
    public async Task<IActionResult> CrearTrabajador([FromBody] EmployeeCreateReq request)
    {
        Employee trabajador = _mapper.Map<Employee>(request);
        int? id = await _employeeService.CreateEmployeeService(trabajador);
        return Ok("Usuario Creado");
    }
    [HttpGet("{codigo}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(EmployeeFilledRes))]
    public async Task<IActionResult> AutoFilledByCode(string codigo, [FromQuery] string tipoAsistencia)
    {
        if (tipoAsistencia == null)
        {
            return BadRequest("No envió tipo asistencia");
        }
        EmployeeFilledRes? response = await _employeeService.AutoFilledService(codigo, tipoAsistencia);
        if (response == null)
        {
            return BadRequest("No se encontró");
        }
        return Ok(response);
    }
    [HttpPut("{id}")]
    [SwaggerResponse(200, "Operación exitosa")]
    public async Task<IActionResult> ActualizarTrabajador(int id, [FromBody] EmployeeUpdateReq? request)
    {
        if (request == null)
        {
            return BadRequest("Invalido");
        }
        int? idEmployee = await _employeeService.Actualizar(id, request);
        if (idEmployee == null)
        {
            return NotFound("No se encontró");
        }
        return Ok($"{idEmployee} ha sido actualizado");
    }
}
