using Directo.Wari.Application.Common.Models;
using Directo.Wari.Application.Features.SPServicios.Dtos;

namespace Directo.Wari.Application.Features.SPServicios.Interfaces
{
    public interface ISPServiciosRepository
    {
        Task<PaginatedList<ServicioWariDto>> ListarServicios(RequestServicioWariDto request);
    }
}
