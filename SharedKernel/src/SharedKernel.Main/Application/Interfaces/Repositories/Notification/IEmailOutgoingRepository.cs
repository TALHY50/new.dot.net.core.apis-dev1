using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace SharedKernel.Main.Application.Interfaces.Repositories.Notification;

public interface IEmailOutgoingRepository
{
    Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}