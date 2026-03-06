using Directo.Wari.Application.Common.Models;
using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Queries.ListarServicios
{
    public sealed record ListarServiciosQuery(ServicioWariRequestDto Request) : IRequest<PaginatedList<ServicioWariResponseDto>>;
}
