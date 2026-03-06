using Directo.Wari.Application.Features.EmpresaAuthorization.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.EmpresaAuthorization.Queries.GetEmpresaAuthorization
{
    public sealed record GetEmpresaAuthorizationQuery(int id) : IRequest<EmpresaResponseInformativoDto?>;
}
