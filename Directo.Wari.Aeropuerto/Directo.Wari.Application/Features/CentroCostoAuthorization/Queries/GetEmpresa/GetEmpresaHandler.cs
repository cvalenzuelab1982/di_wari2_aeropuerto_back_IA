using Directo.Wari.Application.Features.CentroCostoAuthorization.Dtos;
using Directo.Wari.Application.Features.CentroCostoAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.CentroCostoAuthorization.Queries.GetEmpresa
{
    public class GetEmpresaHandler : IRequestHandler<GetEmpresaQuery, List<CentroCostoResponseDto>>
    {
        private readonly ICentroCostoAuthorizationRepository _repository;

        public GetEmpresaHandler(ICentroCostoAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CentroCostoResponseDto>> Handle(GetEmpresaQuery request, CancellationToken cancellationToken)
        {
            return await _repository.WhereEmpresa(request.id);
        }
    }

}
