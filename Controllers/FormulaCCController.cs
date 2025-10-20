// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using Proy_back_QBD.Dto.Request;
// using Proy_back_QBD.Dto.Response;
// using Proy_back_QBD.Models;
// using Proy_back_QBD.Services;
// using Swashbuckle.AspNetCore.Annotations;

// namespace Proy_back_QBD.Controllers;

// [ApiController]
// [Route("api/formula")]
// public class FormulaCCController : ControllerBase
// {
//     private readonly IFormulaService _formulaService;

//     public FormulaCCController(IFormulaService formulaService)
//     {
//         _formulaService = formulaService;
//     }

//     [HttpPost]
//     [SwaggerResponse(200, "Operación exitosa", typeof(FormulaCreateResponse))]
//     public async Task<IActionResult> CrearFormula([FromBody] FormulaCreateReq request)
//     {
//         if (request == null)
//         {
//             return BadRequest("Request cannot be null");
//         }
//         FormulaCreateResponse? response = await _formulaService.CrearFormPed(request);
//         return Ok(response);
//     }
    
    
// }