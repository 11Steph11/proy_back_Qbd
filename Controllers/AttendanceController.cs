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
[Route("asistencia")]
public class AttendanceController : ControllerBase
{

    private readonly IAttendanceService _asistenciaService;
    private readonly IMapper _mapper;

    public AttendanceController(IAttendanceService userService, IMapper mapper)
    {
        _asistenciaService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(AttendanceCreateRes))]
    public async Task<IActionResult> CrearAsistencia([FromBody] AttendanceCreateReq request)
    {
        Asistencia asistencia = _mapper.Map<Asistencia>(request);
        AttendanceCreateRes response = await _asistenciaService.RegistrarAsistenciaAsync(asistencia);
        return Ok(response);
    }

    // [HttpGet]
    // [SwaggerResponse(200, "Operación exitosa", typeof(AsistenciaCreateResponse))]
    // public async Task<IActionResult> ObtenerAsistenciaByDNI([FromBody] AsistenciaByDNIRequest request)
    // {
    //     // Validar que el mes sea válido (de 1 a 12)

    //     // Devolver la respuesta en formato JSON
    //     return Ok();

    // }
}
