using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.EmpresaAuthorization.Dtos;

namespace Directo.Wari.Application.Features.EmpresaAuthorization.Interfaces
{
    public interface IEmpresaAuthorizationRepository
    {
        Task<List<EmpresaResponseSimpleDto>> All(ClienteResponseDto? cliente);
        Task<EmpresaResponseInformativoDto?> Get(int id);
    }
}
