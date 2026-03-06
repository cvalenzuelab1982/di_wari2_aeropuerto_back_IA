using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.Cliente.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.Cliente.Queries.ClienteConEmpresa
{
    public class ClienteConEmpresaHandler : IRequestHandler<ClienteConEmpresaQuery, ClienteResponseDto?>
    {
        private readonly IClienteRepository _repository;

        public ClienteConEmpresaHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClienteResponseDto?> Handle(ClienteConEmpresaQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Where(request.Id);
        }
    }

}
