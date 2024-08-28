
namespace IMT.App.Domain.Entities;

public class BusinessHoursAndWeekends
{
    public int Id { get; set; }

    public byte HourType { get; set; } = 0;

    public int CountryId { get; set; }

    public string Day { get; set; } = string.Empty;

    public bool IsWeekend { get; set; } = false;

    public sbyte Gmt { get; set; }

    public DateTime OpenAt { get; set; }

    public DateTime CloseAt { get; set; }

    public int CompanyId { get; set; } = 0;

    public byte Status { get; set; } = 1;

    public int CreatedById { get; set; }

    public int UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
