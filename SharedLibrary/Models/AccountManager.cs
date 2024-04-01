using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class AccountManager
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int MerchantId { get; set; }
}
