using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("api/pedido")]
public class PedidoController : ControllerBase
{

    private readonly IPedidoService _pedidoService;

    public PedidoController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(PedidoCreateResponse))]
    public async Task<IActionResult> CrearPedido([FromBody] PedidoCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }
        PedidoCreateResponse? response = await _pedidoService.Crear(request);
        return Ok(response);
    }
    [HttpPut("{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(PedidoUpdateReq))]
    public async Task<IActionResult> ActualizarPedido(int id, [FromBody] PedidoUpdateReq request)
    {
        if (request == null)
        {
            return BadRequest("Datos incorrectos");
        }
        PedidoUpdateResponse? response = await _pedidoService.Actualizar(id, request);

        return Ok(response);
    }
    [HttpDelete("{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(Pedido))]
    public async Task<IActionResult> EliminarPedido(int id)
    {
        if (id == null)
        {
            return BadRequest("Datos incorrectos");
        }
        Pedido? response = await _pedidoService.Eliminar(id);

        return Ok(response);
    }
    [HttpGet]
    [SwaggerResponse(200, "Creacion exitosa", typeof(List<PedidoFindAllResponse?>))]
    public async Task<IActionResult> ObtenerPedidos()
    {
        List<PedidoFindAllResponse?> response = await _pedidoService.Obtener();

        return Ok(response);
    }
}
