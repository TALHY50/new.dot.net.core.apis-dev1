using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Application.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
            
            var error = Error.Unexpected(
                code: ApplicationStatusCodes.API_ERROR_UNEXPECTED_ERROR.ToString(),
                description: ex.ToString());

            return (dynamic)error;

           // throw;
        }
    }
}