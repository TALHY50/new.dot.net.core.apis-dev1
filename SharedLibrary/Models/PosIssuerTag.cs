using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PosIssuerTag
{
    public int Id { get; set; }

    public int? PosId { get; set; }

    public int? BankId { get; set; }
}
