using Directo.Wari.Application.Features.EmpresaAuthorization.Dtos;
using Directo.Wari.Application.Features.EmpresaAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.EmpresaAuthorization.Queries.GetEmpresaAuthorization
{
    public class GetEmpresaAuthorizationHandler : IRequestHandler<GetEmpresaAuthorizationQuery, EmpresaResponseInformativoDto?>
    {
        private readonly IEmpresaAuthorizationRepository _repository;

        public GetEmpresaAuthorizationHandler(IEmpresaAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmpresaResponseInformativoDto?> Handle(GetEmpresaAuthorizationQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.id);
        }
    }
}
