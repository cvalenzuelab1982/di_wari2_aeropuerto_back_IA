using Directo.Wari.Application.Common.Responses;
using Directo.Wari.Application.Features.ClienteAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.ClienteAuthorization.Queries.GetComprobantePredeterminadoCliente
{
    public class GetComprobantePredeterminadoClienteHandler : IRequestHandler<GetComprobantePredeterminadoClienteQuery, BeanGeneric?>
    {
        private readonly IClienteAuthorizationRepository _repository;

        public GetComprobantePredeterminadoClienteHandler(IClienteAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<BeanGeneric?> Handle(GetComprobantePredeterminadoClienteQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetComprobantePredeterminadoCliente(request.IdCliente);
        }
    }
}
