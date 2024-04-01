using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Setting
{
    public uint Id { get; set; }

    public string Key { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? Value { get; set; }

    public string? Details { get; set; }

    public string Type { get; set; } = null!;

    public int Order { get; set; }

    public string? Group { get; set; }

    public string? Title { get; set; }

    public string? MetaTag { get; set; }

    public string? LogoPath { get; set; }

    public string? FaviconPath { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? AdminPhone { get; set; }

    public string? AdminName { get; set; }

    public string? CompanyAddress { get; set; }

    public string? Footer { get; set; }

    /// <summary>
    /// Admin panel footer copyright area tr version
    /// </summary>
    public string? FooterTr { get; set; }

    public string? Advertisment { get; set; }

    public int CompanyId { get; set; }
}
