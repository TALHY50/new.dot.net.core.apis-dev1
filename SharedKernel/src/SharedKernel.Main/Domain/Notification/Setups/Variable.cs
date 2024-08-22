#nullable disable
namespace SharedKernel.Main.Domain.Notification.Setups
{
    public class Variable
    {
        public int Id { get; set; }
        public string VariableName { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}