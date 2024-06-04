using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Response.CreditParties;

namespace IMT.Thunes.Adapter.CreditParties
{
    public class InformationAdapter : BaseAdapter
    {
        public InformationAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public InformationResponse CreditPartyInformation(InformationRequest request, ulong id, string transaction_type)
        {
            var path = $"/v2/money-transfer/payers/{id}/{transaction_type}/credit-party-information";
            return RestClient.Post<InformationResponse>(RequestOptions.BaseUrl + path,
                CreateHeaders(request, path, RequestOptions),
                request);
        }

    }
}