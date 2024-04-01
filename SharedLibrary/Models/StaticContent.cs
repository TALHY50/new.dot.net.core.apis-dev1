using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class StaticContent
{
    public int Id { get; set; }

    /// <summary>
    /// en, tr
    /// </summary>
    public string? LanguageCode { get; set; }

    /// <summary>
    /// user aggreement, policy, faq
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// section tabs title
    /// </summary>
    public string? SectionTitle { get; set; }

    /// <summary>
    /// section tabs content
    /// </summary>
    public string? SectionContent { get; set; }

    /// <summary>
    /// 1=active, 0=inactive
    /// </summary>
    public sbyte? Status { get; set; }

    /// <summary>
    /// sorting the section tabs
    /// </summary>
    public int? SectionOrder { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? UpdatedByUserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
