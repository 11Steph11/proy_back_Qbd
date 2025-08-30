using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Request;
using Proy_back_QBD.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers;

[ApiController]
[Route("usuario")]
public class UsuarioController : ControllerBase
{

    private readonly IUserService _userService;

    public UsuarioController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    [SwaggerResponse(200, "Operación exitosa", typeof(UsuarioLoginDataRes))]
    public async Task<IActionResult> ValidarCredenciales([FromBody] UsuarioLoginReq request)
    {
        if (request == null || request.Usuario == null || request.Contrasena == null)
        {
            return BadRequest("Datos mal enviados");
        }
        UsuarioLoginDataRes? usuario = await _userService.ValidarLogin(request.Usuario, request.Contrasena);

        return Ok(usuario);
    }

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(Usuario))]
    public async Task<IActionResult> CrearUsuario([FromBody] UsuarioCreateReq request)
    {
        Usuario? usuario = await _userService.Crear(request);

        return Ok(usuario);
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(Usuario))]
    public async Task<IActionResult> EliminarUsuario(int id)
    {
        Usuario? usuario = await _userService.Eliminar(id);
        return Ok(usuario);
    }

    [HttpPut("{id}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(UsuarioUpdateReq))]
    public async Task<IActionResult> ActualizarUsuario(int id, UsuarioUpdateReq request)
    {
        Usuario? usuario = await _userService.Actualizar(id, request);
        return Ok(usuario);
    }
    [HttpGet]
    [SwaggerResponse(200, "Operación exitosa", typeof(UsuarioListaRes))]
    public async Task<IActionResult> ObtenerUsuarios()
    {
        List<UsuarioListaRes>? usuario = await _userService.Listar();
        return Ok(usuario);
    }
    [HttpGet("{id}")]
    [SwaggerResponse(200, "Operación exitosa", typeof(UsuarioByIdRes))]
    public async Task<IActionResult> ObtenerUsuariosPorId(int id)
    {
        UsuarioByIdRes? usuario = await _userService.ObtenerById(id);
        return Ok(usuario);
    }
}
