using Directo.Wari.Application.Common.Models;
using Directo.Wari.Application.Features.SPServicios.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.SPServicios.Queries.ListarServicios
{
    public sealed record ListarServiciosQuery(RequestServicioWariDto Request) : IRequest<PaginatedList<ServicioWariDto>>;
}
