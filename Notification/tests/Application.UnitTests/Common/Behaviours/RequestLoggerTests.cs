using Microsoft.Extensions.Logging;

using Moq;

using Notification.Application.Common.Behaviours;
using Notification.Application.Common.Interfaces;
using Notification.Application.Features.TodoItems;

namespace Notification.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private readonly Mock<ILogger<CreateOutgoingCommand>> _logger;
    private readonly Mock<ICurrentUserService> _currentUserService;

    public RequestLoggerTests()
    {
        _logger = new Mock<ILogger<CreateOutgoingCommand>>();
        _currentUserService = new Mock<ICurrentUserService>();
    }

    [Fact]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateOutgoingCommand>(_logger.Object, _currentUserService.Object);

        await requestLogger.Process(new CreateOutgoingCommand(1, "title"), CancellationToken.None);
    }

    [Fact]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateOutgoingCommand>(_logger.Object, _currentUserService.Object);

        await requestLogger.Process(new CreateOutgoingCommand(1, "title"), CancellationToken.None);
    }
}