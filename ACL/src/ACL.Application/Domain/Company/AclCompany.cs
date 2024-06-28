namespace ACL.Application.Domain.Company;

public partial class AclCompany
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string Cname { get; set; } = null!;

    public string Cemail { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string Postcode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Logo { get; set; } = null!;

    public string RegistrationNo { get; set; } = null!;

    public int Timezone { get; set; }

    /// <summary>
    /// 1=&gt;email,2=&gt;username
    /// </summary>
    public sbyte UniqueColumnName { get; set; }

    public string TimezoneValue { get; set; } = null!;

    public string TaxNo { get; set; } = null!;

    public string? TaxOffice { get; set; }

    public string? Sector { get; set; }

    public double AverageTurnover { get; set; }

    public int NoOfEmployees { get; set; }

    public sbyte CmmiLevel { get; set; }

    public double YearlyRevenue { get; set; }

    public double HourlyRate { get; set; }

    public double DailyRate { get; set; }

    /// <summary>
    /// 1=active,0=inactive
    /// </summary>
    public sbyte Status { get; set; }

    public int AddedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
