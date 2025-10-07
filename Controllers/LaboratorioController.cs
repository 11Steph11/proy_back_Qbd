using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proy_back_QBD.Dto.Productos;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Proy_back_QBD.Controllers
{
    [ApiController]
    [Route("api/laboratorio")]
    public class LaboratorioController : Controller
    {
        private readonly ILogger<LaboratorioController> _logger;
        private readonly ILaboratorioService _labService;

        public LaboratorioController(ILogger<LaboratorioController> logger, ILaboratorioService labService)
        {
            _logger = logger;
            _labService = labService;
        }

        [HttpGet]
        [SwaggerResponse(200, "Lista exitosa", typeof(List<PedidoLab>))]
        public async Task<IActionResult> ListarPedidosLab(int pageNumber = 1)
        {
            List<PedidoLab> response = await _labService.ListaLab(pageNumber);

            return Ok(response);
        }
        [HttpGet("{cod}")]
        [SwaggerResponse(200, "Lista exitosa", typeof(LabFindPedIdRes))]
        public async Task<IActionResult> ListarPedidosLab(string cod)
        {
            LabFindPedIdRes? response = await _labService.ObtenerByCod(cod);
            
            if (response == null)
            {
                return NotFound("");
            }
            
            return Ok(response);
        }


    }
}