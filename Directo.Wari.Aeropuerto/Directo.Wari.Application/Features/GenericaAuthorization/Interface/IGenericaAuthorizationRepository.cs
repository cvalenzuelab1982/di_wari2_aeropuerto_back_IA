using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.GenericaAuthorization.Dto;

namespace Directo.Wari.Application.Features.GenericaAuthorization.Interface
{
    public interface IGenericaAuthorizationRepository
    {
        Task<List<GenericaResponseDto>> Get(GetRequestDto request, ClienteResponseDto? cliente);
    }
}
