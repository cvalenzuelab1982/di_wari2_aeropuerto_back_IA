using Directo.Wari.Application.Features.Cliente.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.ClienteAuthorization.Queries.GetClienteEmpresa
{
    public sealed record GetClienteEmpresaQuery(int idEmpresa, string query) : IRequest<List<ClienteResponseDto>>;
}
