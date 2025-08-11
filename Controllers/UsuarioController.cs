using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
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

    [HttpPost]
    [SwaggerResponse(200, "Operación exitosa", typeof(UsuarioLoginRes))]
    public async Task<IActionResult> ValidarCredenciales([FromBody] UsuarioLoginReq request)
    {
        var usuario = await _userService.ValidarLoginUserAsync(request.Usuario, request.Contrasena);
        return Ok(usuario);
    }
}
