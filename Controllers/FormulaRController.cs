using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Auxiliares;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/formula")]
public class FormulaRController : ControllerBase
{

    private readonly IFormulaRService _formulaRService;

    public FormulaRController(IFormulaRService formulaService)
    {
        _formulaRService = formulaService;
    }

    [HttpGet("sede/{sedeId}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(FormulaRRes))]
    public async Task<IActionResult> ListaFormulaR(int sedeId)
    {

        List<FormulaRRes>? response = await _formulaRService.ListaFormulaR(sedeId);

        return Ok(response);
    }
}
