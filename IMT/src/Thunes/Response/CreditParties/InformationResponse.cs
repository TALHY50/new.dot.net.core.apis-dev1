using Beneficiary = Thunes.Response.CreditParties.Common.Beneficiary;

namespace Thunes.Response.CreditParties
{
    public class InformationResponse
    {
        public Beneficiary beneficiary { get; set; }
        public int id { get; set; }
    }
}