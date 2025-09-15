using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;
using Proy_back_QBD.Response.Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/cobro")]
public class CobroController : ControllerBase
{

    private readonly ICobroService _cobroService;

    public CobroController(ICobroService cobroService)
    {
        _cobroService = cobroService;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(Cobro))]
    public async Task<IActionResult> CrearCobro([FromBody] CobroCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }
        Cobro? response = await _cobroService.Crear(request);
        return Ok(response);
    }

    [HttpPut("{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(Cobro))]
    public async Task<IActionResult> ActualizarCobro(int id, [FromBody] CobroUpdateReq request)
    {
        if (request == null)
        {
            return BadRequest("Datos incorrectos");
        }
        Cobro? response = await _cobroService.Actualizar(id, request);

        return Ok(response);
    }

    // [HttpDelete("{id}")]
    // [SwaggerResponse(200, "Creacion exitosa", typeof(Cobro))]
    // public async Task<IActionResult> EliminarCobro(int id)
    // {
    //     if (id == null)
    //     {
    //         return BadRequest("Datos incorrectos");
    //     }
    //     Cobro? response = await _cobroService.Eliminar(id);

    //     return Ok(response);
    // }
}
