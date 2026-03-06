using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using Directo.Wari.Application.Features.ServicioAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Queries.ObtenerServicio
{
    public class ObtenerServicioHandler : IRequestHandler<ObtenerServicioQuery, ServicioFullWariResponseDto?>
    {
        private readonly IServicioAuthorizationRepository _repository;

        public ObtenerServicioHandler(IServicioAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServicioFullWariResponseDto?> Handle(ObtenerServicioQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ObtenerServicio(request.IdServicio);
        }
    }
}
