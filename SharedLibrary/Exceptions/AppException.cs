using System;

namespace SharedLibrary.Exceptions;

public class AppException : Exception
{
    public int ExceptionCode { get; set; }
    
    public AppException(string message, int exceptionCode) : base(message)
    {
        ExceptionCode = exceptionCode;
    }

}