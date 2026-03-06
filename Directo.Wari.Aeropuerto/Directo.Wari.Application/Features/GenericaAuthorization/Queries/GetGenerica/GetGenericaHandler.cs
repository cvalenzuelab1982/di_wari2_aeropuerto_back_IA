using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.Cliente.Interfaces;
using Directo.Wari.Application.Features.GenericaAuthorization.Dto;
using Directo.Wari.Application.Features.GenericaAuthorization.Interface;
using MediatR;

namespace Directo.Wari.Application.Features.GenericaAuthorization.Queries.GetGenerica
{
    public class GetGenericaHandler : IRequestHandler<GetGenericaQuery, List<GenericaResponseDto>>
    {
        private readonly IGenericaAuthorizationRepository _repository;
        private readonly IClienteRepository _clienteRepository;

        public GetGenericaHandler(IGenericaAuthorizationRepository repository, IClienteRepository clienteRepository)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<GenericaResponseDto>> Handle(GetGenericaQuery request, CancellationToken cancellationToken)
        {
            ClienteResponseDto? cliente = null;

            if (request.Request.idCliente.HasValue)
            {
                cliente = await _clienteRepository.Where(request.Request.idCliente.Value);
            }

            return await _repository.Get(request.Request!, cliente);
        }
    }
}
