namespace SharedKernel.Main.Notification.Contracts;

public record SmsReceivers(
    string Receivers = "",
    bool IsAllowFromApp = true);