namespace ACL.Core.Models;

public partial class AclState
{
    public ulong Id { get; set; }
    public ulong CountryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } = null!;

    public byte Status { get; set; }

    public ulong Sequence { get; set; }

    public ulong CreatedById { get; set; }

    public ulong UpdatedById { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
