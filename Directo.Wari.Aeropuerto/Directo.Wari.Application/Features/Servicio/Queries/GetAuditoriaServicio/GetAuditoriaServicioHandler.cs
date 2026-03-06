using Directo.Wari.Application.Common.Constants;
using Directo.Wari.Application.Common.Responses;
using Directo.Wari.Application.Features.Servicio.Dtos;
using Directo.Wari.Application.Features.Servicio.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Directo.Wari.Application.Features.Servicio.Queries.GetAuditoriaServicio
{
    public class GetAuditoriaServicioHandler : IRequestHandler<GetAuditoriaServicioQuery, BeanGenericClass<BeanAuditoriaWariResponseDto>>
    {
        private readonly IServicioRepository _repository;
        private readonly ILogger<GetAuditoriaServicioHandler> _logger;

        public GetAuditoriaServicioHandler(IServicioRepository repository, ILogger<GetAuditoriaServicioHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<BeanGenericClass<BeanAuditoriaWariResponseDto>> Handle(GetAuditoriaServicioQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _repository.GetAuditoriaServicio(request.IdServicio);
                var result = new BeanGenericClass<BeanAuditoriaWariResponseDto>
                {
                    IdResultado = BeanConfiguracion.HTTP_OK_NOMSG,
                    List = list
                };
                return result;
            }
            catch (Exception ex)
            {
                var result = new BeanGenericClass<BeanAuditoriaWariResponseDto>
                {
                    IdResultado = BeanConfiguracion.HTTP_ERROR_NOMSG
                };
                _logger.LogError(ex, "Excepción no controlada: {Message},{result}", ex.Message, result);
                return result;
            }
        }
    }
}
