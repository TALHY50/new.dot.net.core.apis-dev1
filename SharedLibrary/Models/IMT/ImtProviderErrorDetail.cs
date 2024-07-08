using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.IMT
{
    public partial class ImtProviderErrorDetail
    {
        public int Id { get; set; }

        public int ImtProviderId { get; set; }

        /// <summary>
        /// 1: quotation,2: money_transfer
        /// </summary>
        public sbyte Type { get; set; }

        /// <summary>
        /// type-reference table primary key id
        /// </summary>
        public int ReferenceId { get; set; }

        public string? ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
