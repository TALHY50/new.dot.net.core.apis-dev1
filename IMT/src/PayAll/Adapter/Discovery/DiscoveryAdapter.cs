using PayAll.Net;
using PayAll.Request.Common;
using PayAll.Response.Discovery;
using PayAll.Route;

namespace PayAll.Adapter.Discovery
{
    public class DiscoveryAdapter : BaseAdapter
    {
        public DiscoveryAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }
        // Get list of payment accounts
        public DiscoveryResponse GetRequiredPaymentFields()
        {
            var path = PayAllUrl.GetRequiredPaymentFieldsUrl;

            return RestClient.Get<DiscoveryResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));

        }
    }
}
