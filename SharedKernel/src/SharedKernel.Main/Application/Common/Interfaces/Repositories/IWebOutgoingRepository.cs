using SharedKernel.Main.Domain.Notifications.Outgoings;

namespace SharedKernel.Main.Application.Common.Interfaces.Repositories;

public interface IWebOutgoingRepository
{
    Task<WebOutgoing?> FindActiveRecordByIdAsync(int id, CancellationToken cancellationToken);
}