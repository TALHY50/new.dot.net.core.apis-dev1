using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PfHistory
{
    public int Id { get; set; }

    public string? MerchantId { get; set; }

    public string Ip { get; set; } = null!;

    public string? BankCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
