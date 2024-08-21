using SharedKernel.Main.Domain.Notifications.Outgoings;

namespace SharedKernel.Main.Application.Common.Interfaces.Repositories;

public interface IEmailOutgoingRepository
{
    Task<EmailOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}