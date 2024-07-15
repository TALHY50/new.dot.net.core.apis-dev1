#nullable disable
namespace Notification.Application.Domain.Setups
{
    public class Layout
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public bool IsDefault { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long CompanyId { get; set; }
    }
}