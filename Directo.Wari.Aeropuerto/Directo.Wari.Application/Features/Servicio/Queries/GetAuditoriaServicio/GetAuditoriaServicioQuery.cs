using Directo.Wari.Application.Common.Responses;
using Directo.Wari.Application.Features.Servicio.Dtos;
using MediatR;

namespace Directo.Wari.Application.Features.Servicio.Queries.GetAuditoriaServicio
{
    public sealed record GetAuditoriaServicioQuery(int IdServicio) : IRequest<BeanGenericClass<BeanAuditoriaWariResponseDto>>;
}
