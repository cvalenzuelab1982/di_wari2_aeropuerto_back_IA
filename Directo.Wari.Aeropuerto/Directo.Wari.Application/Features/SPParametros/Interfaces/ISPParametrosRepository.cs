using Directo.Wari.Application.Features.SPParametrosLista.Dtos;

namespace Directo.Wari.Application.Features.SPParametrosLista.Interfaces
{
    public interface ISPParametrosRepository
    {
        Task<ParametroListaDto?> getParameterStringNull(string key);
    }
}
