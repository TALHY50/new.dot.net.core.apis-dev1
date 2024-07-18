using Thunes.Net;
using Thunes.Request.Common;
using Thunes.Request.Transaction.Quoatation;
using Thunes.Response.Transfer.Quotation;
using Thunes.Route;

namespace Thunes.Adapter.Transfers.Quotations
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

        public CreateContentQuotationResponse GetQuotationByExternalId(ulong external_id)
        {
            string url = ThunesUrl.RetrieveQuotationByExternalIdUrl.Replace("{external_id}", external_id.ToString());
            return RestClient.Get<CreateContentQuotationResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

    }
}