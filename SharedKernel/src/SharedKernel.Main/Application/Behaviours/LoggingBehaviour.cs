using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedKernel.Main.Application.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUser _currentUser;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUser currentUser)
    {
        _logger = logger;
        _currentUser = currentUser;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUser.UserId ?? string.Empty;

        return Task.Run(
            () => _logger.LogInformation(
            "Request: {Name} {@UserId} {@Request}",
            requestName,
            userId,
            request),
            cancellationToken);
    }
}