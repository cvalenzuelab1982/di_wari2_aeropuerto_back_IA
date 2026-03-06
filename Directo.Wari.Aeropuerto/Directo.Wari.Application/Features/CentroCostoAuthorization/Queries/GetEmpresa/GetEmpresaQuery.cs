using Directo.Wari.Application.Features.CentroCostoAuthorization.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.CentroCostoAuthorization.Queries.GetEmpresa
{
    public sealed record GetEmpresaQuery(int id) : IRequest<List<CentroCostoResponseDto>>;
}
