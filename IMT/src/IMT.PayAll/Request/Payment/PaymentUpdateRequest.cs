using IMT.PayAll.Request.Common;

namespace IMT.PayAll.Request.Payment
{
    public class PaymentUpdateRequest
    {
        public List<SupportingDocument> supporting_documents { get; set; }
        public string exchange_rate_id { get; set; }
    }

}