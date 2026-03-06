using Asp.Versioning;
using Directo.Wari.Application.Features.PromocionAuthorization.Queries.ObtenerPromocionesPorCliente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Directo.Wari.API.Controllers.V2
{
    /// <summary>
    /// Controller para ClienteAuthorization.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PromocionAuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromocionAuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ObtenerPromocionesPorCliente")]
        public async Task<IActionResult> ObtenerPromocionesPorCliente([FromQuery] int idEmpresa, int idCliente)
        {
            var result = await _mediator.Send(new ObtenerPromocionesPorClienteQuery(idEmpresa, idCliente));
            return Ok(result);  
        }
    }
}
