namespace SharedKernel.Main.Notification.Contracts;

public record WebReceivers(
    string Url,
    bool IsAllowFromApp = true);