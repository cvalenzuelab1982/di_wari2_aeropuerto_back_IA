using Asp.Versioning;
using Directo.Wari.Application.Features.Parametro.Queries.GetParameterStringNull;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Directo.Wari.API.Controllers.V2
{
    /// <summary>
    /// Controller para Parametros autorizados.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ParametroAuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParametroAuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var result = await _mediator.Send(new GetParametroQuery(id));
            return Ok(result);
        }
    }
}
