#nullable disable
using ACL.Application.Domain.ValueObjects;

namespace ACL.Application.Domain.Setups
{
    public class ReceiverGroup
    {
        public int Id { get; set; }

        public NotificationType Type { get; set; }
        public string Name { get; set; }
        public string To { get; set; }
        public string CcEmails { get; set; }
        public string BccEmails { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CompanyId { get; set; }
    }
}