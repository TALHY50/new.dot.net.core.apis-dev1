using Thunes.Net;
using Thunes.Request.Common;
using Thunes.Request.CreditParties;
using Thunes.Response.CreditParties;
using Thunes.Route;

namespace Thunes.Adapter.CreditParties
{
    public class VerificationAdapter : BaseAdapter
    {
        public VerificationAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public VerificationResponse CreditPartyVerification(ulong id, string transaction_type, InformationRequest request)
        {
            var path = ThunesUrl.CreditPartyVerificationUrl.Replace("{id}", id.ToString()).Replace("{transaction_type}", transaction_type);
            return RestClient.Post<VerificationResponse>(RequestOptions.BaseUrl + path,
                CreateHeaders(request, path, RequestOptions),
                request);
        }

    }
}