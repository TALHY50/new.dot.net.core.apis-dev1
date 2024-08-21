namespace SharedKernel.Main.Contracts.Notificaiton.Contracts;

public record WebReceivers(
    string Url,
    bool IsAllowFromApp = true);