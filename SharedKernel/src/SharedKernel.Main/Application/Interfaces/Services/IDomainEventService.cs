using SharedKernel.Main.Domain;

namespace SharedKernel.Main.Application.Interfaces.Services;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}