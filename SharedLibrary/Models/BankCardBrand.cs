using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BankCardBrand
{
    public int Id { get; set; }

    public string BankCode { get; set; } = null!;

    /// <summary>
    /// card brand code of a bank
    /// </summary>
    public string CardBrandCode { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; }
}
