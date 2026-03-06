using Asp.Versioning;
using Directo.Wari.Application.Features.Servicio.Queries.GetAuditoriaServicio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Directo.Wari.API.Controllers.V2
{
    /// <summary>
    /// Controller para Servicio.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("AuditoriaServicio")]
        public async Task<IActionResult> GetAuditoriaServicio([FromQuery] int idServicio)
        {
            var result = await _mediator.Send(new GetAuditoriaServicioQuery(idServicio));
            return Ok(result);  
        }
    }
}
