﻿namespace SharedKernel.Main.Domain.IMT.Entities;

public partial class ProviderService
{
    public int Id { get; set; }

    public int ImtProviderId { get; set; }

    /// <summary>
    /// BankAccount, WalletTransfer etc
    /// </summary>
    public string? Name { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}