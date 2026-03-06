using Directo.Wari.Application.Features.PromocionAuthorization.Dtos;
using Directo.Wari.Application.Features.PromocionAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.PromocionAuthorization.Queries.ObtenerPromocionesPorCliente
{
    public class ObtenerPromocionesPorClienteHandler : IRequestHandler<ObtenerPromocionesPorClienteQuery, PromocionResponseDto?>
    {
        private readonly IPromocionAuthorizationRepository _repository;

        public ObtenerPromocionesPorClienteHandler(IPromocionAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<PromocionResponseDto?> Handle(ObtenerPromocionesPorClienteQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerPromocionesPorCliente(request.idEmpresa, request.idCliente);
        }
    }
}
