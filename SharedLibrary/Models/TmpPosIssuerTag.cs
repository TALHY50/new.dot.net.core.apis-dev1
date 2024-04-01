using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class TmpPosIssuerTag
{
    public int Id { get; set; }

    public int? TmpPosId { get; set; }

    public int? PosId { get; set; }

    public int? BankId { get; set; }
}
