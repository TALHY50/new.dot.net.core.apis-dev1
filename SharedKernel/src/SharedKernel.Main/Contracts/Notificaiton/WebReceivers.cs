namespace SharedKernel.Main.Contracts.Notificaiton;

public record WebReceivers(
    string Url,
    bool IsAllowFromApp = true);