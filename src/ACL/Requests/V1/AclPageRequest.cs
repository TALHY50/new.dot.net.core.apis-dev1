﻿
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Requests.CustomDataAnotator;

namespace ACL.Requests.V1
{
    public class AclPageRequest
    {
        [DefaultValue(1001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        [ExistsInDatabase("AclModule", "Id")]
        public ulong module_id { get; set; }

        [DefaultValue(2001)]
        [Required]
        [Range(1, ulong.MaxValue)]
        [ExistsInDatabase("AclSubModule", "Id")]
        public ulong sub_module_id { get; set; }

        [DefaultValue("Company List")]
        [Required]
        [StringLength(100)]
        public string name { get; set; } = null!;

        [DefaultValue("index")]
        [Required]
        [StringLength(100)]
        public string method_name { get; set; } = null!;

        [DefaultValue(1)]
        [Required]
        [Range(1, 4)]
        public int method_type { get; set; }
    }
}