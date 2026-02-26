using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Directo.Wari.Application.Features.SPParametros;

namespace Directo.Wari.API.Controllers.V2
{

    /// <summary>
    /// Controller para Servicio sobre Reservas.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ServicioAuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicioAuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarServiciosWari/{codigo}")]
        public async Task<IActionResult> ListarServiciosWari(string codigo)
        {
            var result = await _mediator.Send(new SPParametrosQuery(codigo));
            return Ok(new { message = "Endpoint pendiente de implementación" });
        }
    }
}
