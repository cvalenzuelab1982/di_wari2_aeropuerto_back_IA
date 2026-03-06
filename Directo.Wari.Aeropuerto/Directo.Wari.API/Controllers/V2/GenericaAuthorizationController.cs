using Asp.Versioning;
using Directo.Wari.Application.Features.GenericaAuthorization.Dto;
using Directo.Wari.Application.Features.GenericaAuthorization.Queries.GetGenerica;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Directo.Wari.API.Controllers.V2
{
    /// <summary>
    /// Controller para Servicios genericos para combos, etc.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GenericaAuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenericaAuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var result = await _mediator.Send(new GetGenericaQuery(new GetRequestDto { id = id }));
            return Ok(result);
        }
    }
}
