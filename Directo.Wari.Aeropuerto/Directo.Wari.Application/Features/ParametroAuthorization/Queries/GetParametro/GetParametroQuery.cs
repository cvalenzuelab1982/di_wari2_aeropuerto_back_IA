using Directo.Wari.Application.Features.Parametro.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.Parametro.Queries.GetParameterStringNull
{
    public sealed record GetParametroQuery(string id) : IRequest<ParametroResponseDto>;
}
