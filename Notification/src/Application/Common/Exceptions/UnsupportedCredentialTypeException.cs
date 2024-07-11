namespace Notification.Application.Common.Exceptions;

public class UnsupportedCredentialTypeException : Exception
{
    public UnsupportedCredentialTypeException()
    {
    }

    public UnsupportedCredentialTypeException(int credentialType)
        : base($"CredentialType '{credentialType}' is unsupported.")
    {
    }

    public UnsupportedCredentialTypeException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}