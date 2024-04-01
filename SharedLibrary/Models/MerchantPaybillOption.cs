using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantPaybillOption
{
    public int Id { get; set; }

    public int MerchantId { get; set; }

    public int PaybillOptionId { get; set; }
}
