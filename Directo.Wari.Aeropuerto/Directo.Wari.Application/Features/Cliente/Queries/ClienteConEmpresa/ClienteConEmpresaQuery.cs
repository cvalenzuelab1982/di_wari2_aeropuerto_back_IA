using Directo.Wari.Application.Features.Cliente.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.Cliente.Queries.ClienteConEmpresa
{
    public sealed record ClienteConEmpresaQuery(int Id) : IRequest<ClienteResponseDto>;
}
