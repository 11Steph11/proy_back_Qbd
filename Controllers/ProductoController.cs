using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/prod")]
public class ProductoController : ControllerBase
{

    private readonly IProductoService _productoService;

    public ProductoController(IProductoService prodTermService)
    {
        _productoService = prodTermService;
    }

    [HttpGet("/{sedeId}")]
    [SwaggerResponse(200, "Obtencion exitosa", typeof(ProductoRes))]
    public async Task<IActionResult> Obtener(int sedeId)
    {
        List<ProductoRes>? response = new();

        response = await _productoService.Obtener(sedeId);

        return Ok(response);
    }
    [HttpGet("secure-data")]
    public IActionResult GetSecureData()
    {
        // Este endpoint estará protegido por el middleware que valida el código.
        return Ok(new { message = "Datos protegidos, solo accesibles con el código correcto" });
    }
}
