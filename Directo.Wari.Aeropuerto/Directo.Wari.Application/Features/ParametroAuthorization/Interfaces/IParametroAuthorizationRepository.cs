using Directo.Wari.Application.Features.Parametro.Dtos;

namespace Directo.Wari.Application.Features.Parametro.Interfaces
{
    public interface IParametroAuthorizationRepository
    {
        Task<ParametroResponseDto?> GetParametro(string id);
    }
}
