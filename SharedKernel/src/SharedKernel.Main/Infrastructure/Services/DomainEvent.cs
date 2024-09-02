using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Models;
using SharedKernel.Main.Domain;

namespace SharedKernel.Main.Infrastructure.Services;

public class DomainEvent : IDomainEventService
{
    private readonly ILogger<DomainEvent> _logger;
    private readonly IPublisher _mediator;

    public DomainEvent(ILogger<DomainEvent> logger, IPublisher mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public Task Publish(Domain.DomainEvent domainEvent)
    {
        _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
        return _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
    }

    private INotification GetNotificationCorrespondingToDomainEvent(Domain.DomainEvent domainEvent)
    {
        return (INotification)Activator.CreateInstance(
            typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent)!;
    }
}