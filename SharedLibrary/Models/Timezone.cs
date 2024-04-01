using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Timezone
{
    public int Id { get; set; }

    public string CountryCode { get; set; } = null!;

    public string TimeZone1 { get; set; } = null!;

    public string UtcOffset { get; set; } = null!;

    public string UtcDstOffset { get; set; } = null!;
}
