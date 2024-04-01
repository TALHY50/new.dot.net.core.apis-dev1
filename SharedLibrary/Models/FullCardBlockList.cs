using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class FullCardBlockList
{
    public int Id { get; set; }

    /// <summary>
    /// primary key of cc_block_list table
    /// </summary>
    public int CcBlockListId { get; set; }

    /// <summary>
    /// Card is being stored as hash
    /// </summary>
    public string HashedCard { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
