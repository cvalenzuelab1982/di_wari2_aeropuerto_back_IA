using Asp.Versioning;
using Directo.Wari.Application.Features.CentroCostoAuthorization.Queries.GetEmpresa;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Directo.Wari.API.Controllers.V2
{
    /// <summary>
    /// Controller para CentroCosto autorizados.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CentroCostoAuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CentroCostoAuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getempresa")]
        public async Task<IActionResult> GetEmpresa([FromQuery] int id)
        {
            var result = await _mediator.Send(new GetEmpresaQuery(id));
            return Ok(result);
        }
    }
}
