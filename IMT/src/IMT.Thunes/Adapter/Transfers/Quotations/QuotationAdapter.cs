using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.Transaction.Quotation;
using IMT.Thunes.Response.Transfer.Quotation;
using IMT.Thunes.Route;


namespace IMT.Thunes.Adapter.Transfers.Quotations
{
    public class QuotationAdapter : BaseAdapter
    {
        public QuotationAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        public CreateContentQuotationResponse CreateQuotation(CreateQuotationRequest request)
        {
            return RestClient.Post<CreateContentQuotationResponse>(RequestOptions.BaseUrl + ThunesUrl.CreateQuotationUrl,
                CreateHeaders(request, ThunesUrl.CreateQuotationUrl, RequestOptions), request);
        }
        public CreateContentQuotationResponse GetQuotationById(ulong id)
        {
            string url = ThunesUrl.RetrieveAQuotationByIdUrl.Replace("{id}", id.ToString());
            return RestClient.Get<CreateContentQuotationResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public CreateContentQuotationResponse GetRetrieveQuotationByExternalId(ulong external_id)
        {
            string url = ThunesUrl.RetrieveQuotationByExternalIdUrl.Replace("{external_id}", external_id.ToString());
            return RestClient.Get<CreateContentQuotationResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

    }
}