using Directo.Wari.Application.Common.Models;
using Directo.Wari.Application.Features.ServicioAuthorization.Dtos;

namespace Directo.Wari.Application.Features.ServicioAuthorization.Interfaces
{
    public interface IServicioAuthorizationRepository
    {
        Task<PaginatedList<ServicioWariResponseDto>> ListarServicios(ServicioWariRequestDto request);
        Task<List<ServicioWariResponseDto>> FiltroBusquedaServicio(FiltroBusquedaServicioRequestDto request);
        Task<ServicioFullWariResponseDto?> ObtenerServicio(int IdServicio);
        Task<List<HistorialServicioWariResponseDto>> ObtenerServicioByIdCliente(int Idcliente);
    }
}
