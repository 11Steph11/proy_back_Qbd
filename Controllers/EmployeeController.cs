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
        int? id = await _employeeService.RegistrarTrabajadorAsync(trabajador);
        EmployeeCreateRes response = new EmployeeCreateRes();
        response.Id = id;
        return Ok(response);
    }
    [HttpGet("{codigo}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(EmployeeFilledRes))]
    public async Task<IActionResult> AutoFilledByCode(string codigo, [FromQuery] string tipoAsistencia)
    {
        EmployeeFilledReq request = new EmployeeFilledReq
        {
            Codigo = codigo,
            TipoAsistencia = tipoAsistencia
        };
        EmployeeFilledRes? response = await _employeeService.AutoFilled(request);
        if (response == null)
        {
            return BadRequest("Error");
        }
        return Ok(response);
    }
}
