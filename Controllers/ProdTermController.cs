using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/prodTerm")]
public class ProdTermController : ControllerBase
{

    private readonly IProdTermService _prodTermService;

    public ProdTermController(IProdTermService prodTermService)
    {
        _prodTermService = prodTermService;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(ProdTerm))]
    public async Task<IActionResult> CrearProdTerm([FromBody] ProdTermCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }
        ProdTerm? response = await _prodTermService.Crear(request);
        return Ok(response);
    }
    [HttpPut("{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(ProdTerm))]
    public async Task<IActionResult> ActualizarProdTerm(int id, [FromBody] ProdTermUpdateReq request)
    {
        if (request == null)
        {
            return BadRequest("Datos incorrectos");
        }
        ProdTerm? response = await _prodTermService.Actualizar(id, request);

        return Ok(response);
    }
    [HttpDelete("{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(ProdTerm))]
    public async Task<IActionResult> EliminarProdTerm(int id)
    {
        ProdTerm? response = await _prodTermService.Eliminar(id);
        if (response == null)
        {
            return NotFound("No hay");
        }
        return Ok(response);
    }
    
}
