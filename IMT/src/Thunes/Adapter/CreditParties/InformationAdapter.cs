using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Exception;
using IMT.Thunes.Net;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Response.CreditParties;
using IMT.Thunes.Route;

namespace IMT.Thunes.Adapter.CreditParties
{
    public class InformationAdapter : BaseAdapter
    {
        public InformationAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public InformationResponse CreditPartyInformation(InformationRequest request, ulong id, string transaction_type)
        {
            var path = ThunesUrl.CreditPartiesInformationUrl.Replace("{id}", id.ToString()).Replace("{transaction_type}", transaction_type);
            return RestClient.Post<InformationResponse>(RequestOptions.BaseUrl + path,
                CreateHeaders(request, path, RequestOptions),
                request);


        }

    }
}