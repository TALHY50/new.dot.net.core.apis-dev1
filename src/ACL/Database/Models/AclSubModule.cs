using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ACL.Database.Models;

public partial class AclSubModule
{
    [Required(ErrorMessage = "ID is required.")]
    [Column("id")]
    public ulong Id { get; set; }

    [Column("module_id")]
    [Required(ErrorMessage = "Module ID is required.")]
    public ulong ModuleId { get; set; }

    [Column("name")]
    [Required(ErrorMessage = "Name is required.")]
    public  string Name { get; set; }

    [Column("controller_name")]
    [Required(ErrorMessage = "ControllerName is required.")]
    public  string ControllerName { get; set; }

    [Column("icon")]
    [Required(ErrorMessage = "Icon is required.")]
    public  string Icon { get; set; }

    [Column("sequence")]
    [Required(ErrorMessage = "Sequence is required.")]
    public int Sequence { get; set; }

    [Column("default_method")]
    [Required(ErrorMessage = "DefaultMethod is required.")]
    public  string DefaultMethod { get; set; }

    [Column("display_name")]
    [Required(ErrorMessage = "DisplayName is required.")]
    public  string DisplayName { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
