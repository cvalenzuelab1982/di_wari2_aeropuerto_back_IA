using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Queries.FiltroBusquedaServicio
{
    public sealed record FiltroBusquedaServicioQuery(FiltroBusquedaServicioRequestDto Request) : IRequest<List<ServicioWariResponseDto>>;
}
