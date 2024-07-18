namespace App.Domain.IMT;

public partial class ImtCity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CountryId { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
