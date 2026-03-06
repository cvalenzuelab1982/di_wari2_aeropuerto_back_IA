using Directo.Wari.Application.Common.Responses;
using MediatR;

namespace Directo.Wari.Application.Features.ClienteAuthorization.Queries.GetComprobantePredeterminadoCliente
{
    public sealed record GetComprobantePredeterminadoClienteQuery(int IdCliente) : IRequest<BeanGeneric?>;
}
