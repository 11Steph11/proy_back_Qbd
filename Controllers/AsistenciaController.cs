using Proy_back_QBD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using System.Diagnostics;
namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("asistencia")]
public class AsistenciaController : ControllerBase
{

    private readonly IAsistenciaService _asistenciaService;
    private readonly IMapper _mapper;

    public AsistenciaController(IAsistenciaService userService, IMapper mapper)
    {
        _asistenciaService = userService;
        _mapper = mapper;
    }

    // [HttpPost]
    // [SwaggerResponse(200, "Operación exitosa", typeof(AsistenciaCreateRes))]
    // public async Task<IActionResult> CrearAsistencia([FromBody] AsistenciaCreateReq request)
    // {
    //     if (request == null)
    //     {
    //         return BadRequest("Datos de asistencia no proporcionados");
    //     }
    //     Debug.WriteLine(request);
    //     Asistencia asistencia = new Asistencia();
    //     asistencia.Tipo = request.Tipo;
    //     asistencia.Codigo = request.Codigo;
    //     asistencia.HoraAsignada = request.HoraAsignada;
    //     asistencia.Observacion = request.Observacion;
    //     Debug.WriteLine(asistencia);
    //     AsistenciaCreateRes? response = await _asistenciaService.Registrar(asistencia);
    //     if (response == null)
    //     {
    //         return BadRequest("Error al crear la asistencia");
    //     }
    //     return Ok(response);
    // }

    [HttpPost("codigo/{codigo}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(AsistenciaByCodigoRes))]
    public async Task<IActionResult> ObtenerAsistenciaByCodigo(string codigo , [FromBody] AsistenciaByCodigoReq request)
    {
        if (request == null || string.IsNullOrEmpty(codigo))
        {
            return BadRequest("Código de asistencia no proporcionado");
        }
        AsistenciaByCodigoRes? response = await _asistenciaService.ListarPorCodigo(codigo, request.Año, request.Mes);
        return Ok(response);
    }

    
}
