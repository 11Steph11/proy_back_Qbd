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
    [SwaggerResponse(200, "Operación exitosa", typeof(PedidoCreateRes))]
    public async Task<IActionResult> CrearPedido([FromBody] PedidoCreateReq request)
    {
        if (request == null)
        {
            return BadRequest("Request cannot be null");
        }
        PedidoCreateRes? response = await _pedidoService.Crear(request);
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
    [HttpPatch("comprobante/{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(Pedido))]
    public async Task<IActionResult> AgregarBoleta(int id, string? comprobante)
    {
        if (id == null)
        {
            return BadRequest("Datos incorrectos");
        }
        Pedido? response = await _pedidoService.ActComprobante(id, comprobante);

        return Ok(response);
    }
    [HttpPatch("estado/{id}")]
    public async Task<IActionResult> ActualizarEstado(int id, string estado)
    {
        if (id == null)
        {
            return BadRequest("Datos incorrectos");
        }
        string? response = await _pedidoService.ActEstado(id, estado);

        return Ok(response);
    }
    [HttpGet]
    [SwaggerResponse(200, "Creacion exitosa", typeof(List<PedidoFindAllResponse?>))]
    public async Task<IActionResult> ObtenerPedidos(int sedeId)
    {
        List<PedidoFindAllResponse?> response = await _pedidoService.Listar(sedeId);

        return Ok(response);
    }
    
    [HttpGet("lab/{sedeId}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(List<PedidoLabFindAllRes?>))]
    public async Task<IActionResult> ObtenerPedidosLab(int sedeId)
    {
        List<PedidoLabFindAllRes2?> response = await _pedidoService.ListarLab(sedeId);

        return Ok(response);
    }

    [HttpGet("{id}")]
    [SwaggerResponse(200, "Creacion exitosa", typeof(PedidoFindIdResponse))]
    public async Task<IActionResult> ObtenerPedidosId(int id)
    {
        PedidoFindIdResponse? response = await _pedidoService.ObtenerById(id);
        if (response == null)
        {
            return NotFound("No se encontrò");
        }
        return Ok(response);
    }
}
