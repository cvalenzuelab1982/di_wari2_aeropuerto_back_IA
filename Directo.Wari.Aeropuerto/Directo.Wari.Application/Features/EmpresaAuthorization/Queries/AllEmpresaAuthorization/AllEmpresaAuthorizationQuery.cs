using Directo.Wari.Application.Features.EmpresaAuthorization.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.EmpresaAuthorization.Queries.AllEmpresaAuthorization
{
    public sealed record AllEmpresaAuthorizationQuery(int? idCliente = null) : IRequest<List<EmpresaResponseSimpleDto>>;
}
