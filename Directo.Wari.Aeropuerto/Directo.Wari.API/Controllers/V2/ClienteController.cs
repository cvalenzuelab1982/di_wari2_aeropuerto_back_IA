using Asp.Versioning;
using Directo.Wari.Application.Features.Cliente.Queries.ObtenerRutina;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Directo.Wari.API.Controllers.V2
{
    /// <summary>
    /// Controller para Cliente.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ObtenerRutina")]
        public async Task<IActionResult> ObtenerRutina([FromQuery] int idCliente, int idEmpresa)
        {
            var result = await _mediator.Send(new ObtenerRutinaQuery(idCliente, idEmpresa));
            return Ok(result);
        }
    }
}
