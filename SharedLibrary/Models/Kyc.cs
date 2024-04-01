using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Kyc
{
    public int Id { get; set; }

    public string Tckn { get; set; } = null!;

    public string DobYear { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
