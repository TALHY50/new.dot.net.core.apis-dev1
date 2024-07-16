namespace Notification.App.Contracts;

public record WebReceivers(
    string Url,
    bool IsAllowFromApp = true);