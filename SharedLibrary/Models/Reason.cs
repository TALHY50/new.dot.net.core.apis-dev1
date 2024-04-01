using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Reason
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? TitleTr { get; set; }

    public sbyte? CategoryId { get; set; }

    public string? CategoryCode { get; set; }

    /// <summary>
    /// 1=&gt;Active, 0=&gt;Inactive
    /// </summary>
    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
