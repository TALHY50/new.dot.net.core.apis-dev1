using SharedKernel.Main.Notification.Domain.Entities.Outgoings;

namespace SharedKernel.Main.Notification.Application.Interfaces.Repositories;

public interface IEmailOutgoingRepository
{
    Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}