using Directo.Wari.Application.Features.CentroCostoAuthorization.Dtos;

namespace Directo.Wari.Application.Features.CentroCostoAuthorization.Interfaces
{
    public interface ICentroCostoAuthorizationRepository
    {
        Task<List<CentroCostoResponseDto>> WhereEmpresa(int id);
    }
}
