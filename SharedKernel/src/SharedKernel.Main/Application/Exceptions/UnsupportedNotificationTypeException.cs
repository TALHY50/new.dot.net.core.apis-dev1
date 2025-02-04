namespace SharedKernel.Main.Application.Exceptions;

public class UnsupportedNotificationTypeException : Exception
{
    public UnsupportedNotificationTypeException()
    {
    }

    public UnsupportedNotificationTypeException(int notificationType)
        : base($"NotificationType '{notificationType}' is unsupported.")
    {
    }

    public UnsupportedNotificationTypeException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}