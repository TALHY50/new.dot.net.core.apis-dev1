using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SaleTaxInfo
{
    public int Id { get; set; }

    public int SaleId { get; set; }

    public double BankInsuranceTaxDividend { get; set; }

    public double BankInsuranceTaxMultiplier { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
