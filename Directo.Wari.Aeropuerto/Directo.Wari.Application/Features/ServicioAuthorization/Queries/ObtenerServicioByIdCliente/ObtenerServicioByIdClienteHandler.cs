using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using Directo.Wari.Application.Features.ServicioAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Queries.ObtenerServicioByIdCliente
{
    public class ObtenerServicioByIdClienteHandler : IRequestHandler<ObtenerServicioByIdClienteQuery, List<HistorialServicioWariResponseDto>>
    {
        private readonly IServicioAuthorizationRepository _repository;

        public ObtenerServicioByIdClienteHandler(IServicioAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<HistorialServicioWariResponseDto>> Handle(ObtenerServicioByIdClienteQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerServicioByIdCliente(request.idcliente);
        }
    }
}
