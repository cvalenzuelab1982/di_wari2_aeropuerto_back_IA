using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.ClienteAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.ClienteAuthorization.Queries.GetClienteEmpresa
{
    public class GetClienteEmpresaHandler : IRequestHandler<GetClienteEmpresaQuery, List<ClienteResponseDto>>
    {
        private readonly IClienteAuthorizationRepository _repository;

        public GetClienteEmpresaHandler(IClienteAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClienteResponseDto>> Handle(GetClienteEmpresaQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetClienteEmpresa(request.idEmpresa, request.query);
        }
    }
}
