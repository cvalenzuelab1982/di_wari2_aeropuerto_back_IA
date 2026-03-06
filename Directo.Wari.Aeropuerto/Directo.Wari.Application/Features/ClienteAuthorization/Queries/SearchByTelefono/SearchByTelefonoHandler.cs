using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.ClienteAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.ClienteAuthorization.Queries.SearchByTelefono
{
    public class SearchByTelefonoHandler : IRequestHandler<SearchByTelefonoQuery, List<ClienteResponseDto>>
    {
        private readonly IClienteAuthorizationRepository _repository;

        public SearchByTelefonoHandler(IClienteAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClienteResponseDto>> Handle(SearchByTelefonoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.SearchByTelefono(request.telefono);
        }
    }
}
