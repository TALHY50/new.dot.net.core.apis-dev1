namespace ACL.Bussiness.Domain.Entities;

public partial class UsertypeSubmodule
{
    public ulong Id { get; set; }

    public byte UserTypeId { get; set; }

    public uint SubModuleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
