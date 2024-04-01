using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserHideMerchant
{
    public int Id { get; set; }

    /// <summary>
    /// admin user id
    /// </summary>
    public int UserId { get; set; }

    public string? Data { get; set; }
}
