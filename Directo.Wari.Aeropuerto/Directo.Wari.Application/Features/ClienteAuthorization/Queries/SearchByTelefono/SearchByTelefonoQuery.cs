using Directo.Wari.Application.Features.Cliente.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.ClienteAuthorization.Queries.SearchByTelefono
{
    public sealed record SearchByTelefonoQuery(string telefono) : IRequest<List<ClienteResponseDto>>;
}
