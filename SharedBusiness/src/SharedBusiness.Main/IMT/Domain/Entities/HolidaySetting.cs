namespace SharedBusiness.Main.IMT.Domain.Entities;

/// <summary>
/// Type : Master, contrywise holidays
/// </summary>
public partial class HolidaySetting
{
    public uint Id { get; set; }

    public uint? CountryId { get; set; }

    public DateTime Date { get; set; }

    /// <summary>
    /// 0 = full, 1 = half, 2 = quarter, 3 = special
    /// </summary>
    public byte Type { get; set; }

    /// <summary>
    /// GMT offset in hours (e.g., +5, -3)
    /// </summary>
    public sbyte Gmt { get; set; }

    /// <summary>
    /// Time to start if type is not full
    /// </summary>
    public DateTime? OpenAt { get; set; }

    /// <summary>
    /// Time to end if type is not full
    /// </summary>
    public DateTime? CloseAt { get; set; }

    public uint? CompanyId { get; set; }

    /// <summary>
    /// 0=inactive, 1=active, 2=pending, 3=rejected 
    /// </summary>
    public byte Status { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
