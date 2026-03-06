using Directo.Wari.Application.Features.Servicio.Dtos;

namespace Directo.Wari.Application.Features.Servicio.Interfaces
{
    public interface IServicioRepository
    {
        Task<List<BeanAuditoriaWariResponseDto>> GetAuditoriaServicio(int IdServicio);
    }
}
