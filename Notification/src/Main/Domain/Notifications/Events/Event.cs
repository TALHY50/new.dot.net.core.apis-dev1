#nullable disable
namespace ACL.Application.Domain.Notifications.Events
{
    public class Event
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public bool IsEmail { get; set; }
        public bool IsSms { get; set; }
        public bool IsWeb { get; set; }
        public bool IsAllowFromApp { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}