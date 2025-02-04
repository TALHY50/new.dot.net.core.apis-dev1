﻿using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedKernel.Main.Application.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUser _currentUser;

    public PerformanceBehaviour(
        ILogger<TRequest> logger,
        ICurrentUser currentUser)
    {
        _timer = new Stopwatch();

        _logger = logger;
        _currentUser = currentUser;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUser.UserId ?? string.Empty;

            _logger.LogWarning(
                "Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                requestName,
                elapsedMilliseconds,
                userId,
                request);
        }

        return response;
    }
}