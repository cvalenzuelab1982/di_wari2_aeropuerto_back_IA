using Directo.Wari.Application.Common.Responses;
using Directo.Wari.Application.Features.Cliente.Dtos;

namespace Directo.Wari.Application.Features.ClienteAuthorization.Interfaces
{
    public interface IClienteAuthorizationRepository
    {
        Task<List<ClienteResponseDto>> SearchByTelefono(string telefono);
        Task<List<ClienteResponseDto>> GetClienteEmpresa(int idEmpresa, string query);
        Task<BeanGeneric?> GetComprobantePredeterminadoCliente(int IdCliente);
    }
}
