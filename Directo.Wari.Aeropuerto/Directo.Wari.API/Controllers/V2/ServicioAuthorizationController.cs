using Asp.Versioning;
using Directo.Wari.Application.Features.SPParametros;
using Directo.Wari.Application.Features.SPServicios.Dtos;
using Directo.Wari.Application.Features.SPServicios.Queries.ListarServicios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("ListarServiciosWari")]
        public async Task<IActionResult> ListarServiciosWari([FromBody] RequestServicioWariDto request)
        {
            var result = await _mediator.Send(new ListarServiciosQuery(request));
            return Ok(result);
        }
    }
}
