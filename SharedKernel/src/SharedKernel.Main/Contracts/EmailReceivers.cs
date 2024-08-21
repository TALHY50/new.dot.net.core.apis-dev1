namespace SharedKernel.Main.Contracts;

public record EmailReceivers(
    string Receivers = "",
    bool IsAllowCc = false,
    bool IsAllowBcc = false,
    bool IsAllowFromApp = false);