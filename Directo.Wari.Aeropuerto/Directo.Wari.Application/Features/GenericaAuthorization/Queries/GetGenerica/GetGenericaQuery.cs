using Directo.Wari.Application.Features.GenericaAuthorization.Dto;
using MediatR;

namespace Directo.Wari.Application.Features.GenericaAuthorization.Queries.GetGenerica
{
    public sealed record GetGenericaQuery(GetRequestDto Request) : IRequest<List<GenericaResponseDto>>;
}
