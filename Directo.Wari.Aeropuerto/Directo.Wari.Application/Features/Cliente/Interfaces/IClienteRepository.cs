using Directo.Wari.Application.Features.Cliente.Dtos;

namespace Directo.Wari.Application.Features.Cliente.Interfaces
{
    public interface IClienteRepository
    {
        Task<ClienteResponseDto?> Where(int id);
        Task<List<BeanRutinaResponseDto>> ObtenerRutina(int idcliente, int idEmpresa);
    }
}
