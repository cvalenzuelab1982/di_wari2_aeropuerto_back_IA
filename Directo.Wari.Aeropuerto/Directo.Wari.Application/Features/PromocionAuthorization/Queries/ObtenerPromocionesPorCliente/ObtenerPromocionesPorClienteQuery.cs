using Directo.Wari.Application.Features.PromocionAuthorization.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.PromocionAuthorization.Queries.ObtenerPromocionesPorCliente
{
    public sealed record ObtenerPromocionesPorClienteQuery(int idEmpresa, int idCliente) : IRequest<PromocionResponseDto?>;
}
