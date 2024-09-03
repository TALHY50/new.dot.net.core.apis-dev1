using Thunes.Net;
using Thunes.Request.Common;
using Thunes.Request.CreditParties;
using Thunes.Response.CreditParties;
using Thunes.Route;

namespace Thunes.Adapter.CreditParties
{
    public class InformationAdapter : BaseAdapter
    {
        public InformationAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public InformationResponse CreditPartyInformation(InformationRequest request, uint id, string transaction_type)
        {
            var path = ThunesUrl.CreditPartiesInformationUrl.Replace("{id}", id.ToString()).Replace("{transaction_type}", transaction_type);
            return RestClient.Post<InformationResponse>(RequestOptions.BaseUrl + path,
                CreateHeaders(request, path, RequestOptions),
                request);


        }

    }
}