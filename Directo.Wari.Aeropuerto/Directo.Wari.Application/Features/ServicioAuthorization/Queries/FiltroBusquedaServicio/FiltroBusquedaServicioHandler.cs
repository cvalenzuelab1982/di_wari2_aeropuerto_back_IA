using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using Directo.Wari.Application.Features.ServicioAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Queries.FiltroBusquedaServicio
{
    public class FiltroBusquedaServicioHandler : IRequestHandler<FiltroBusquedaServicioQuery, List<ServicioWariResponseDto>>
    {
        private readonly IServicioAuthorizationRepository _repository;

        public FiltroBusquedaServicioHandler(IServicioAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ServicioWariResponseDto>> Handle(FiltroBusquedaServicioQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FiltroBusquedaServicio(request.Request);
        }
    }
}
