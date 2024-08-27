using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Main.Domain.IMT.Entities
{
    public partial class QuotationInfo
    {
        public uint Id { get; set; }
        public decimal? Amount { get; set; }
        public uint? CurrencyId { get; set; }
        public decimal? Commission { get; set; }
        public decimal? CommissionFixed { get; set; }
        public decimal? CommissionPercentage { get; set; }
        public decimal? Cot { get; set; }
        public decimal? CotPercentage { get; set; }
        public decimal? CotFixed { get; set; }
        public decimal? MarkUp { get; set; }
        public decimal? MarkUpPercentage { get; set; }
        public decimal? MarkUpFixed { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TaxPercentage { get; set; }
        public decimal? TaxFixed { get; set; }
        public decimal? SentAmount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
