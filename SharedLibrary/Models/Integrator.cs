using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Integrator
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? IntegratorName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public double DefaultCommissionPercentage { get; set; }

    public double DefaultCommissionFixed { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 0=inactive, 1=active
    /// </summary>
    public sbyte? IsCustomLogin { get; set; }

    /// <summary>
    /// unique custom url name
    /// </summary>
    public string? UrlName { get; set; }

    /// <summary>
    /// custom login logo
    /// </summary>
    public string? LoginLogo { get; set; }

    /// <summary>
    /// 0 = Does not have installment, 1 = Has installments
    /// </summary>
    public sbyte IsAllowedInstallmentCommission { get; set; }
}
