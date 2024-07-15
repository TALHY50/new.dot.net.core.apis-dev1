namespace Notification.Application.Contracts;

public record WebReceivers(
    string Url,
    bool IsAllowFromApp = true);