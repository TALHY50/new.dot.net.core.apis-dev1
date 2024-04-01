using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class HolidaySetting
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Code { get; set; }

    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
