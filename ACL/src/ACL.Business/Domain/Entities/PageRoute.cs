namespace ACL.Business.Domain.Entities;

public partial class PageRoute
{
    public uint Id { get; set; }

    public uint? PageId { get; set; }

    public string? RouteName { get; set; }

    public string? RouteUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
