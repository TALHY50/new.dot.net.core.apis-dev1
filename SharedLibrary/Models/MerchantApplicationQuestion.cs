using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class MerchantApplicationQuestion
{
    public int Id { get; set; }

    /// <summary>
    /// ENT = 1, Blocllist = 2, Applications = 3, Error = 4, Operation = 5 
    /// </summary>
    public int? Type { get; set; }

    public string? QuestionTitle { get; set; }
}
