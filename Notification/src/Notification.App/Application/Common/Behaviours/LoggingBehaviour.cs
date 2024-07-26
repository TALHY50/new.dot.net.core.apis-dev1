using MediatR.Pipeline;

using Notification.App.Application.Common.Interfaces;

namespace Notification.App.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Rient");
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId ?? string.Empty;

        return Task.Run(
            () => _logger.LogInformation(
            "VerticalSlice Request: {Name} {@UserId} {@Request}",
            requestName,
            userId,
            request),
            cancellationToken);
    }
}