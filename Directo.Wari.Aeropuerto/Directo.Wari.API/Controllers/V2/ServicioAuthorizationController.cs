using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("ListarServiciosWari")]
        public async Task<IActionResult> ListarServiciosWari()
        {
            return Ok(new { message = "Endpoint pendiente de implementación" });
        }
    }
}
