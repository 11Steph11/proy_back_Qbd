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
public class EmployeeController : ControllerBase
{

    private readonly IEmployeeService _trabajadorService;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeService userService, IMapper mapper)
    {
        _trabajadorService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(UserLoginRes))]
    public async Task<IActionResult> CrearTrabajador([FromBody] EmployeeCreateReq request)
    {
        Employee trabajador = _mapper.Map<Employee>(request);
        int? id = await _trabajadorService.RegistrarTrabajadorAsync(trabajador);        
        EmployeeCreateRes response = new EmployeeCreateRes();
        response.Id = id;
        return Ok(response);
    }
}
