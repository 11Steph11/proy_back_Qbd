using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Insumo;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/insumo")]
public class InsumoController : ControllerBase
{

    private readonly IInsumoService _insumoService;

    public InsumoController(IInsumoService insumoService)
    {
        _insumoService = insumoService;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(Pedido))]
    public async Task<IActionResult> CrearInsumo([FromBody] InsumoCreateReq request)
    {
        Insumo? usuario = await _insumoService.Crear(request);
        if (usuario == null)
        {
            NotFound("No existe");
        }
        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(Pedido))]
    public async Task<IActionResult> EliminarInsumo(int id)
    {
        Insumo? usuario = await _insumoService.Eliminar(id);
        if (usuario == null)
        {
            NotFound("No existe");
        }
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(InsumoUpdateReq))]
    public async Task<IActionResult> ActualizarInsumo(int id, InsumoUpdateReq request)
    {
        Insumo? usuario = await _insumoService.Actualizar(id, request);
        if (usuario == null)
        {
            NotFound("No existe");
        }
        return Ok(usuario);
    }

    [HttpGet("sede/{sedeId}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(InsumoFindAllRes))]
    public async Task<IActionResult> ObtenerInsumos(int sedeId)
    {
        List<InsumoFindAllRes?> usuario = await _insumoService.Obtener(sedeId);
        if (usuario == null)
        {
            NotFound("No existen");
        }
        return Ok(usuario);
    }

    [HttpGet("{id}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(InsumoFindIdRes))]
    public async Task<IActionResult> ObtenerInsumosPorId(int id)
    {
        InsumoFindIdRes? usuario = await _insumoService.ObtenerById(id);
        if (usuario == null)
        {
            NotFound("No existe");
        }
        return Ok(usuario);
    }

}
