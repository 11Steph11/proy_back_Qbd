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
        FormulaCreateResponse? response = await _formulaService.CrearFormPed(request);
        return Ok(response);
    }
    [HttpPut("{id}")]
    [SwaggerResponse(200, "Actualizacion exitosa", typeof(FormulaUpdateResponse))]
    public async Task<IActionResult> ActualizarFormula(int id, [FromBody] FormulaUpdateReq request)
    {
        if (request == null)
        {
            return BadRequest("Datos incorrectos");
        }
        FormulaUpdateResponse? response = await _formulaService.Actualizar(id, request);

        return Ok(response);
    }
    
    [HttpGet("etiqueta/{formulaId}")]
    [SwaggerResponse(200, "Actualizacion exitosa", typeof(EtiquetaRes))]
    public async Task<IActionResult> ObtenerEtiqueta(int formulaId)
    {
        EtiquetaRes? response = await _formulaService.ObtenerEtiqueta(formulaId);
        if (response == null) return NotFound();
        return Ok(response);
    }
    [HttpGet("detalles/{formulaId}")]
    [SwaggerResponse(200, "Actualizacion exitosa", typeof(DetallesRes))]
    public async Task<IActionResult> ObtenerDetalles(int formulaId)
    {
        DetallesRes? response = await _formulaService.ObtenerDetalles(formulaId);
        if (response == null) return NotFound();
        return Ok(response);
    }

    [HttpPut("lab/{formulaId}")]
    [SwaggerResponse(200, "Actualizacion exitosa", typeof(FormulaUpdateResponse))]
    public async Task<IActionResult> ActualizarFormulaLaboratorio(int formulaId, [FromBody] FormulaUpdLabReq request)
    {
        if (request == null)
        {
            return BadRequest("Datos incorrectos");
        }
        Formula? response = await _formulaService.ActualizarLab(formulaId, request);
        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
    [HttpPatch("formulaM/{id}")]
    [SwaggerResponse(200, "Actualizacion exitosa", typeof(Formula))]
    public async Task<IActionResult> ActualizarFormulaMagistral(int id, string FormulaMagistral)
    {
        if (FormulaMagistral == null)
        {
            return BadRequest("Datos incorrectos");
        }
        Formula? response = await _formulaService.ActualizarFormulaM(id, FormulaMagistral);

        return Ok(response);
    }
    [HttpPatch("inserto/{formulaId}")]
    [SwaggerResponse(200, "Actualizacion exitosa", typeof(string))]
    public async Task<IActionResult> AgregarInserto(int formulaId, string inserto)
    {
        if (inserto == null)
        {
            return BadRequest("Datos incorrectos");
        }
        string? response = await _formulaService.AgregarInserto(formulaId, inserto);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(Formula))]
    public async Task<IActionResult> EliminarFormula(int id)
    {
        if (id == null)
        {
            return BadRequest("Datos incorrectos");
        }
        Formula? response = await _formulaService.Eliminar(id);

        return Ok(response);
    }
    [HttpGet("receta/{sedeId}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(List<RecetaRes>))]
    public async Task<IActionResult> ListarReceta(int sedeId)
    {
        List<RecetaRes>? response = await _formulaService.ListarReceta(sedeId);

        return Ok(response);
    }
    [HttpGet("formulasLab/{pedidoId}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(FormulasLab))]
    public async Task<IActionResult> ListarFormulasLab(int pedidoId)
    {
        FormulasLab? response = await _formulaService.ListarFormulasLab(pedidoId);
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
}
