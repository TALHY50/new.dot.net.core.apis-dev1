using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities
{
    public class InstitutionAppSetting : EntityBase<uint>, IAggregateRoot
    {
        public uint InstitutionId { get; set; }
        public string? AppName { get; set; }
        public string? AppId { get; set; }
        public string? AppSecret { get; set; }
        public string? Token { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public uint? CreatedById { get; set; }
        public uint? UpdatedById { get; set; }
    }
}
