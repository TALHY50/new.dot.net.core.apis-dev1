namespace SharedKernel.Main.Domain.Admin.Provider
{
    public class AdminProvider
    {
        public ulong Id { get; set; }
        public required string Name { get; set; }
        public string? Code { get; set; }
        public string? BaseUrl { get; set; }
        public ulong? CreatedBy { get; set; }
        public ulong? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}