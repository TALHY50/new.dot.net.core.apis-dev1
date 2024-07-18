namespace App.Domain.IMT;

public partial class ImtCustomer
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    /// <summary>
    /// tckn is government national id
    /// </summary>
    public string? Tckn { get; set; }

    /// <summary>
    /// 1=individual, 2=corporate etc
    /// </summary>
    public sbyte? Type { get; set; }

    /// <summary>
    /// 1=verified, 2=not verified, 3=verified+
    /// </summary>
    public sbyte? Category { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    /// <summary>
    /// 1=approved,2= not approvec, 3=active, 4=inactive, 5=suspended, 6=banned etc
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? Dob { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? CustomerNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
