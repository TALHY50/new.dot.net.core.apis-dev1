using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Domain.IMT.Entities
{
    public partial class QuotationRequest
    {
        public uint Id { get; set; } // `uint` for unsigned int
        public string Request { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
