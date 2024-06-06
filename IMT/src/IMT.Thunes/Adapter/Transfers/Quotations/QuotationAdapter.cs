using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response.Transfer.Quotation;
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

        public CreateContentQuatationResponse GetRetrieveQuotationByExternalId(ulong external_id)
        {
            string url = ThunesUrl.RetrieveQuotationByExternalIdUrl.Replace("{external_id}", external_id.ToString());
            return RestClient.Get<CreateContentQuatationResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }
    }
}