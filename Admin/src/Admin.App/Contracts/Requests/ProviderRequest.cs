namespace ADMIN.Application.Contracts.Requests
{
    public class ProviderRequest
    {
        public required string Name { get; set; }
        public string? Code { get; set; }
        public string? BaseUrl { get; set; }
    }
}