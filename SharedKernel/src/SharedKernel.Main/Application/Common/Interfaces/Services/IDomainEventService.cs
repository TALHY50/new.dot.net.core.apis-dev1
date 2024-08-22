namespace SharedKernel.Main.Application.Common.Interfaces.Services;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}