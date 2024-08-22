namespace SharedKernel.Main.Application.Common.Exceptions;

public class UnsupportedTransportDriverTypeException : Exception
{
    public UnsupportedTransportDriverTypeException()
    {
    }

    public UnsupportedTransportDriverTypeException(string code)
        : base($"Transportdriver '{code}' is unsupported.")
    {
    }

    public UnsupportedTransportDriverTypeException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}