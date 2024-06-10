using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.PayAll.Net;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response;
using IMT.PayAll.Response.Discovery;
using IMT.PayAll.Route;

namespace IMT.PayAll.Adapter.Discovery
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
