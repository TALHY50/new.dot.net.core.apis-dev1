﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Common.Interfaces;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace SharedKernel.Main.Application.Common.Behaviours;

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
            "Request: {Name} {@UserId} {@Request}",
            requestName,
            userId,
            request),
            cancellationToken);
    }
}