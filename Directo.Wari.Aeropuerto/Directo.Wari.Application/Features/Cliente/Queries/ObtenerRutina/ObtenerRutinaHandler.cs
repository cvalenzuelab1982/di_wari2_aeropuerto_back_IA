using Directo.Wari.Application.Common.Constants;
using Directo.Wari.Application.Common.Responses;
using Directo.Wari.Application.Features.Cliente.Dtos;
using Directo.Wari.Application.Features.Cliente.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Directo.Wari.Application.Features.Cliente.Queries.ObtenerRutina
{
    public class ObtenerRutinaHandler : IRequestHandler<ObtenerRutinaQuery, BeanGenericClass<BeanRutinaResponseDto>>
    {
        private readonly IClienteRepository _repository;
        private readonly ILogger<ObtenerRutinaHandler> _logger;

        public ObtenerRutinaHandler(IClienteRepository repository, ILogger<ObtenerRutinaHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<BeanGenericClass<BeanRutinaResponseDto>> Handle(ObtenerRutinaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _repository.ObtenerRutina(request.idCliente, request.idEmpresa);
                var result = new BeanGenericClass<BeanRutinaResponseDto>
                {
                    IdResultado = BeanConfiguracion.HTTP_OK_NOMSG,
                    List = list
                };
                return result;
            }
            catch (Exception ex)
            {
                var result = new BeanGenericClass<BeanRutinaResponseDto>
                {
                    IdResultado = BeanConfiguracion.HTTP_ERROR_NOMSG
                };
                _logger.LogError(ex, "Excepción no controlada: {Message},{result}", ex.Message, result);
                return result;
            }
        }
    }
}
