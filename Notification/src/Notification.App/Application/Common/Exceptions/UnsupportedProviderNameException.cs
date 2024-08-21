namespace Notification.App.Application.Common.Exceptions;

public class UnsupportedProviderNameException : Exception
{
    public UnsupportedProviderNameException()
    {
    }

    public UnsupportedProviderNameException(string code)
        : base($"Transportdriver '{code}' is unsupported.")
    {
    }

    public UnsupportedProviderNameException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}