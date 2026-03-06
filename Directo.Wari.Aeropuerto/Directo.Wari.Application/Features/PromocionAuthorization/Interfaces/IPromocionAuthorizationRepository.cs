using Directo.Wari.Application.Features.PromocionAuthorization.Dtos;

namespace Directo.Wari.Application.Features.PromocionAuthorization.Interfaces
{
    public interface IPromocionAuthorizationRepository
    {
        Task<PromocionResponseDto?> ObtenerPromocionesPorCliente(int idEmpresa, int idCliente);
    }
}
