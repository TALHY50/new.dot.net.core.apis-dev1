using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class PaymentRecOption
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public const int CREDITCARD = 1;
    public const int MOBILE = 2;
    public const int SIPAYWALLET = 3;
    public const int DEPOSITEFT = 4;
    public const int CASH = 5;

    public static readonly Dictionary<int, string> Options = new Dictionary<int, string>
    {
        { 1, "Credit Card" },
        { 2, "Mobile Payment" },
        { 3, "Wallet" }
    };
}
