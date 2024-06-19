using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMIN.Contracts.Requests
{
    public class ProviderRequest
    {
        public string Name { get; set; }
        public string? Code { get; set; }
        public string? BaseUrl { get; set; }
        public ulong? CreatedBy { get; set; }
        public ulong? UpdatedBy { get; set; }
        public DateTime? CretedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}