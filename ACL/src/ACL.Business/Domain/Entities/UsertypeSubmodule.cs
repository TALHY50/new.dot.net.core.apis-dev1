namespace ACL.Business.Domain.Entities;

public partial class UsertypeSubmodule
{
    public uint Id { get; set; }

    public byte UserTypeId { get; set; }

    public uint SubModuleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
