using Directo.Wari.Application.Common.Models;
using Directo.Wari.Application.Features.SPServicios.Dtos;
using Directo.Wari.Application.Features.SPServicios.Interfaces;
using MediatR;

namespace Directo.Wari.Application.Features.SPServicios.Queries.ListarServicios
{
    public class ListarServiciosHandler : IRequestHandler<ListarServiciosQuery, PaginatedList<ServicioWariDto>>
    {
        private readonly ISPServiciosRepository _repository;

        public ListarServiciosHandler(ISPServiciosRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedList<ServicioWariDto>> Handle(ListarServiciosQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListarServicios(request.Request);
        }
    }
}
