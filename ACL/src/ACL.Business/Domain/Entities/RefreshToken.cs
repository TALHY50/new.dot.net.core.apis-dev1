using Ardalis.SharedKernel;

namespace ACL.Business.Domain.Entities
{
    public class RefreshToken : EntityBase<uint>, IAggregateRoot
    {
        public string? Value { get; set; }
        public bool Active { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
