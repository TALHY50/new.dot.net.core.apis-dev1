using SharedKernel.Main.Contracts;

namespace ACL.Business.Contracts.Responses
{

    //public class ErrorOr<T> : Response
    //{
    //    public T Value { get; set; }

    //    public static ErrorOr<T> Success(T value) => new ErrorOr<T> { IsSuccess = true, Value = value };
    //    public static ErrorOr<T> Failure(string errorMessage) => new ErrorOr<T> { IsSuccess = false, ErrorMessage = errorMessage };
    //}


    public class RefreshTokenResponse : Response
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

}
