using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Migrations;
using Proy_back_QBD.Models;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/formulaCC")]
public class FormulaCCController : ControllerBase
{
    private readonly IFormulaCCService _formulaService;

    public FormulaCCController(IFormulaCCService formulaService)
    {
        _formulaService = formulaService;
    }

    [HttpGet("{formulaId}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(FormulaCCLabRes))]
    public async Task<IActionResult> ObtenerInsumosLab(int formulaId)
    {
        FormulaCCLabRes? response = await _formulaService.ListarInsumosLab(formulaId);
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
    [HttpPut("{formulaId}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(List<FormulaCC>))]
    public async Task<IActionResult> ActualizarFormulas(int formulaId,List<FormulaCCUpdReq> formulas)
    {
        if (formulas == null)
        {
            return BadRequest();
        }
        List<FormulaCC>? response = await _formulaService.Actualizar(formulaId,formulas);
        if (response == null)
        {
            return NotFound();
        }
        return Ok(response);
    }
    
    
}