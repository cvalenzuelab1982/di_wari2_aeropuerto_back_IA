using Directo.Wari.Application.Common.Models;
using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;
using Directo.Wari.Application.Features.ServicioAuthorization.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Queries.ListarServicios
{
    public class ListarServiciosHandler : IRequestHandler<ListarServiciosQuery, PaginatedList<ServicioWariResponseDto>>
    {
        private readonly IServicioAuthorizationRepository _repository;

        public ListarServiciosHandler(IServicioAuthorizationRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedList<ServicioWariResponseDto>> Handle(ListarServiciosQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListarServicios(request.Request);
        }
    }
}
