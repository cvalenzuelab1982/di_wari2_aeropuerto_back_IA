using MediatR;
using Microsoft.Extensions.Logging;

namespace Directo.Wari.Application.Common.Behaviors
{
    /// <summary>
    /// Pipeline behavior que registra información de cada request/response.
    /// </summary>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation(
                "WariDirecto Request: {Name} {@Request}",
                requestName, request);

            var response = await next();

            _logger.LogInformation(
                "WariDirecto Response: {Name} {@Response}",
                requestName, response);

            return response;
        }
    }
}
