using Asp.Versioning;
using Directo.Wari.Application.Features.EmpresaAuthorization.Dtos;
using Directo.Wari.Application.Features.EmpresaAuthorization.Queries.AllEmpresaAuthorization;
using Directo.Wari.Application.Features.EmpresaAuthorization.Queries.GetEmpresaAuthorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Directo.Wari.API.Controllers.V2
{
    /// <summary>
    /// Controller para Empresas autorizados.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmpresaAuthorizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmpresaAuthorizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var result = await _mediator.Send(new AllEmpresaAuthorizationQuery());
            return Ok(result);  
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var result = await _mediator.Send(new GetEmpresaAuthorizationQuery(id));
            return Ok(result);  
        }
    }
}
