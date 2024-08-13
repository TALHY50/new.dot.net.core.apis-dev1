namespace SharedKernel.Main.Domain.IMT;

public partial class Country
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? IsoCode { get; set; }

    public string? Name { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
