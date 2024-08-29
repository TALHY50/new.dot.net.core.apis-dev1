namespace SharedKernel.Main.Application.Common.Constants;

public class ApplicationCodes
{
    public class ApplicationCode(string code, string message)
    {
        public  string Code = code;
        public string Message = message;

    }
    
    
    public static readonly ApplicationCode OperationIsOk = new ApplicationCode("1000", "Success" );


    public static readonly ApplicationCode StringNullOrEmpty = new ApplicationCode("1001", "string is null or empty" );
    
    public static readonly ApplicationCode RecordNotFound = new ApplicationCode("2001", "record not found" );
    
    public static readonly ApplicationCode DatabaseOperationFailed = new ApplicationCode("4001", "dp operation failed" );
    
    public static readonly ApplicationCode Unexpected = new ApplicationCode("5000", "exception!" );
}


