﻿namespace SharedKernel.Main.Domain.IMT;

public partial class CustomerBank
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? CountryId { get; set; }

    public int? CityId { get; set; }

    public int? BankId { get; set; }

    public string? AccountTitle { get; set; }

    public string? AccountNo { get; set; }

    public string? BranchIban { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    /// <summary>
    /// can&apos;t delete if already exist
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}