using Asp.Versioning;
using Directo.Wari.Application.Features.ClienteAuthorization.Queries.GetClienteEmpresa;
using Directo.Wari.Application.Features.ClienteAuthorization.Queries.GetComprobantePredeterminadoCliente;
using Directo.Wari.Application.Features.ClienteAuthorization.Queries.SearchByTelefono;
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
    public class ClienteAuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteAuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("SearchByTelefono")]
        public async Task<IActionResult> SearchByTelefono([FromQuery] string telefono)
        {
            var result = await _mediator.Send(new SearchByTelefonoQuery(telefono));
            return Ok(result);  
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetClienteEmpresa([FromQuery] int idEmpresa, string query)
        {
            var result = await _mediator.Send(new GetClienteEmpresaQuery(idEmpresa, query));
            return Ok(result);
        }

        [HttpGet("GetComprobantePredeterminadoCliente")]
        public async Task<IActionResult> GetComprobantePredeterminadoCliente([FromQuery] int IdCliente)
        {
            var result = await _mediator.Send(new GetComprobantePredeterminadoClienteQuery(IdCliente));
            return Ok(result);  
        }
    }
}
