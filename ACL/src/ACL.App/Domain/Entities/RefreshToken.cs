namespace ACL.App.Domain.Entities
{
    public class RefreshToken
    {
        public string? Value { get; set; }
        public bool Active { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
