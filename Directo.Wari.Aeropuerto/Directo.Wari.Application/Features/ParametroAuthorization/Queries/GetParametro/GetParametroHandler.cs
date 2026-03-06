using Directo.Wari.Application.Features.Parametro.Dtos;
using Directo.Wari.Application.Features.Parametro.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.Parametro.Queries.GetParameterStringNull
{
    public class GetParametroHandler : IRequestHandler<GetParametroQuery, ParametroResponseDto?>
    {
        private readonly IParametroAuthorizationRepository _repository;

        public GetParametroHandler(IParametroAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ParametroResponseDto?> Handle(GetParametroQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetParametro(request.id);
        }
    }
}
