using Asp.Versioning;
using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using Directo.Wari.Application.Features.ServicioAuthorization.Queries.FiltroBusquedaServicio;
using Directo.Wari.Application.Features.ServicioAuthorization.Queries.ListarServicios;
using Directo.Wari.Application.Features.ServicioAuthorization.Queries.ObtenerServicio;
using Directo.Wari.Application.Features.ServicioAuthorization.Queries.ObtenerServicioByIdCliente;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Directo.Wari.Infrastructure.Persistence.Constants.SPName;

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
        public async Task<IActionResult> ListarServiciosWari([FromBody] ServicioWariRequestDto request)
        {
            var result = await _mediator.Send(new ListarServiciosQuery(request));
            return Ok(result);
        }

        [HttpGet("FiltroBusquedaServicioWari")]
        public async Task<IActionResult> FiltroBusquedaServicioWari([FromQuery] string busqueda, int filtro)
        {
            var result = await _mediator.Send(new FiltroBusquedaServicioQuery(new FiltroBusquedaServicioRequestDto { Busqueda = busqueda, Filtro = filtro }));
            return Ok(result);
        }

        [HttpGet("ObtenerServicioWari")]
        public async Task<IActionResult> ObtenerServicioWari([FromQuery] int idServicio)
        {
            var result = await _mediator.Send(new ObtenerServicioQuery(idServicio));
            return Ok(result);
        }

        [HttpGet("ObtenerServicioByIdCliente")]
        public async Task<IActionResult> ObtenerServicioByIdCliente([FromQuery] int IdCliente)
        {
            var result = await _mediator.Send(new ObtenerServicioByIdClienteQuery(IdCliente));
            return Ok(result);
        }
    }
}
