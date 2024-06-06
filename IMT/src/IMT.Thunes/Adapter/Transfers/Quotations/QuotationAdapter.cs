using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response;
using IMT.Thunes.Route;


namespace IMT.Thunes.Adapter.Transfers.Quotations
{
    public class QuotationAdapter : BaseAdapter
    {
        public QuotationAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        public CreateContentQuatationResponse CreateQuatatioin(CreateQuatationRequest request)
        {
            return RestClient.Post<CreateContentQuatationResponse>(RequestOptions.BaseUrl + ThunesUrl.CreateQuatationUrl,
                CreateHeaders(request, ThunesUrl.CreateQuatationUrl, RequestOptions), request);
        }
        public CreateContentQuatationResponse GetQuotationById(int id)
        {
            string url = ThunesUrl.RetrieveAQuotationByIdUrl.Replace("{id}", id.ToString());
            return RestClient.Get<CreateContentQuatationResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public CreateQuatationResponse GetRetrieveQuotationByExternalId(ulong id)
        {
            string url = ThunesUrl.RetrieveQuotationByExternalIdUrl + "/ext-" + id;
            return RestClient.Get(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }
    }
}