using SharedKernel.Main.Domain.Notification.Notifications.Outgoings;

namespace SharedKernel.Main.Application.Common.Interfaces.Notification;

public interface IEmailOutgoingRepository
{
    Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}