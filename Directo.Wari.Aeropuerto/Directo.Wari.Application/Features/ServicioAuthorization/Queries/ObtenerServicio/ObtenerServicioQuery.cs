using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Queries.ObtenerServicio
{
    public sealed record ObtenerServicioQuery(int IdServicio) : IRequest<ServicioFullWariResponseDto>;
}
