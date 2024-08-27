
namespace SharedKernel.Main.IMT.Domain.Entities;

public class HolidaySetting
{
    public int Id { get; set; }

    public int? CountryId { get; set; }

    public DateTime Date { get; set; }

    public byte Type { get; set; }

    public sbyte Gmt { get; set; }

    public DateTime? OpenAt { get; set; }

    public DateTime? CloseAt { get; set; }

    public int CompanyId { get; set; } = 0;

    public byte Status { get; set; } = 1;

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
