using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Page
{
    public int Id { get; set; }

    public int ModuleId { get; set; }

    public int SubModuleId { get; set; }

    public string Name { get; set; } = null!;

    public string MethodName { get; set; } = null!;

    /// <summary>
    /// 1=Post, 2=Get, 3=Put, 4=Delete
    /// </summary>
    public int MethodType { get; set; }

    public bool AvailableToCompany { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
