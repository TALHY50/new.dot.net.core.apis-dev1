namespace IMT.Thunes.Response.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<ErrorsResponse> Errors { get; set; }
    }
}