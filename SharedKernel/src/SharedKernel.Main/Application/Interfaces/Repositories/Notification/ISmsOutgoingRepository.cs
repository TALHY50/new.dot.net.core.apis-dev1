using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace SharedKernel.Main.Application.Interfaces.Repositories.Notification;

public interface ISmsOutgoingRepository
{
    Task<SmsOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}