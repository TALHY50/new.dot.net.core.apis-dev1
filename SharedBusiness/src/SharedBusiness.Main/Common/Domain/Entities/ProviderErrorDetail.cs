using Ardalis.SharedKernel;

namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class ProviderErrorDetail : EntityBase<uint>, IAggregateRoot
{
    public uint ImtProviderId { get; set; }

    public sbyte Type { get; set; }

    public uint ReferenceId { get; set; }

    public string? ErrorCode { get; set; }

    public string? ErrorMessage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
