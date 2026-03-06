using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.Cliente.Interfaces;
using Directo.Wari.Application.Features.EmpresaAuthorization.Dtos;
using Directo.Wari.Application.Features.EmpresaAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.EmpresaAuthorization.Queries.AllEmpresaAuthorization
{
    public class AllEmpresaAuthorizationHandler : IRequestHandler<AllEmpresaAuthorizationQuery, List<EmpresaResponseSimpleDto>>
    {
        private readonly IEmpresaAuthorizationRepository _repository;
        private readonly IClienteRepository _clienteRepository;

        public AllEmpresaAuthorizationHandler(IEmpresaAuthorizationRepository repository, IClienteRepository clienteRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<EmpresaResponseSimpleDto>> Handle(AllEmpresaAuthorizationQuery request, CancellationToken cancellationToken)
        {
            ClienteResponseDto? cliente = null;

            if (request.idCliente.HasValue)
            {
                cliente = await _clienteRepository.Where(request.idCliente.Value);
            }

            return await _repository.All(cliente);
        }
    }
}
