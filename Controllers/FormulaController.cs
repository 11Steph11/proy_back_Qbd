using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/formula")]
public class FormulaController : ControllerBase
{

    private readonly IFormulaService _formulaService;

    public FormulaController(IFormulaService formulaService)
    {
        _formulaService = formulaService;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(FormulaCreateResponse))]
    public async Task<IActionResult> CrearFormula([FromBody] FormulaCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }
        FormulaCreateResponse? response = await _formulaService.Crear(request);
        return Ok(response);
    }
    // [HttpPut("{id}")]
    // [SwaggerResponse(200, "Creacion exitosa", typeof(FormulaUpdateReq))]
    // public async Task<IActionResult> ActualizarFormula(int id, [FromBody] FormulaUpdateReq request)
    // {
    //     if (request == null)
    //     {
    //         return BadRequest("Datos incorrectos");
    //     }
    //     FormulaUpdateResponse? response = await _formulaService.Actualizar(id, request);

    //     return Ok(response);
    // }
    // [HttpDelete("{id}")]
    // [SwaggerResponse(200, "Creacion exitosa", typeof(Formula))]
    // public async Task<IActionResult> EliminarFormula(int id)
    // {
    //     if (id == null)
    //     {
    //         return BadRequest("Datos incorrectos");
    //     }
    //     Formula? response = await _formulaService.Eliminar(id);

    //     return Ok(response);
    // }
}
