﻿using Microsoft.Extensions.Logging;
using Moq;

using Notification.App.Application.Common.Behaviours;
using Notification.App.Application.Common.Interfaces;
using Notification.App.Application.Features.TodoItems;

namespace ACL.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private readonly Mock<ILogger<CreateTodoItemCommand>> _logger;
    private readonly Mock<ICurrentUserService> _currentUserService;

    public RequestLoggerTests()
    {
        _logger = new Mock<ILogger<CreateTodoItemCommand>>();
        _currentUserService = new Mock<ICurrentUserService>();
    }

    [Fact]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateTodoItemCommand>(_logger.Object, _currentUserService.Object);

        await requestLogger.Process(new CreateTodoItemCommand(1, "Log Test"), CancellationToken.None);
    }

    [Fact]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateTodoItemCommand>(_logger.Object, _currentUserService.Object);

        await requestLogger.Process(new CreateTodoItemCommand(1, "UnitTest"), CancellationToken.None);
    }
}