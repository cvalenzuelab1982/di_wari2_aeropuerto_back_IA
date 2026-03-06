using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Queries.ObtenerServicioByIdCliente
{
    public sealed record ObtenerServicioByIdClienteQuery(int idcliente) : IRequest<List<HistorialServicioWariResponseDto>>;
}
