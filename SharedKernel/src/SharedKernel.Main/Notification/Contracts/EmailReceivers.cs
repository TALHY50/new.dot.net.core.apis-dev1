namespace SharedKernel.Main.Notification.Contracts;

public record EmailReceivers(
    string Receivers = "",
    bool IsAllowCc = false,
    bool IsAllowBcc = false,
    bool IsAllowFromApp = false);