using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BlockTimeSetting
{
    public int Id { get; set; }

    public sbyte UserType { get; set; }

    public int FirstTime { get; set; }

    public int SecondTime { get; set; }

    public int ThirdTime { get; set; }

    /// <summary>
    /// as define it will be 10 min. 
    /// </summary>
    public int SessionTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
