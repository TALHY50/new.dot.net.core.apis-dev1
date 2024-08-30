namespace SharedBusiness.Main.Common.Domain.Entities;

public partial class Customer
{
    public uint Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Tckn { get; set; }

    public sbyte? Type { get; set; }

    public sbyte? Category { get; set; }

    public uint? CreatedById { get; set; }

    public uint? UpdatedById { get; set; }

    /// <summary>
    /// 0=inactive, 1= active, 2= pending, 3= blocked, 4=banned, 5=expired, 6=rejected, 7 = approved but not active yet
    /// </summary>
    public byte? Status { get; set; }

    public DateTime? Dob { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? CustomerNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
