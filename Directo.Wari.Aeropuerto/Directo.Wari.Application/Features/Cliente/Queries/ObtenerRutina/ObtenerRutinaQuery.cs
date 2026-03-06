using Directo.Wari.Application.Common.Responses;
using Directo.Wari.Application.Features.Cliente.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.Cliente.Queries.ObtenerRutina
{
    public sealed record ObtenerRutinaQuery(int idCliente, int idEmpresa) : IRequest<BeanGenericClass<BeanRutinaResponseDto>>;
}
