﻿using System.ComponentModel;

namespace ACL.Business.Contracts.Requests
{
    public class AclBranchRequest
    {
        [DefaultValue("Uttara Branch")]
        public required string Name { get; set; }

        [DefaultValue("Uttara sector 11")]
        public required string Address { get; set; }
        [DefaultValue("This is sub branch.")]
        public required string Description { get; set; }
        [DefaultValue(1)]
        public required uint Sequence { get; set; }

        [DefaultValue(1)]
        public int? Status { get; set; }
    }
}
