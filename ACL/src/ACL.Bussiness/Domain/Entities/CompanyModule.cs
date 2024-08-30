namespace ACL.Bussiness.Domain.Entities;

public partial class CompanyModule
{
    public ulong Id { get; set; }

    public ulong CompanyId { get; set; }

    public ulong ModuleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
