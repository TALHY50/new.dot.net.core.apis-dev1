namespace SharedKernel.Main.Contracts
{
    public abstract class Response
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public static Response Success() => new SuccessResponse();
        public static Response Failure(string errorMessage) => new ErrorResponse { ErrorMessage = errorMessage };
    }

    public class SuccessResponse : Response
    {
        public SuccessResponse()
        {
            IsSuccess = true;
        }
    }

    public class ErrorResponse : Response
    {
        public ErrorResponse()
        {
            IsSuccess = false;
        }
    }

    public class DataResponse<T> : SuccessResponse
    {
        public T Data { get; set; }
    }

}
