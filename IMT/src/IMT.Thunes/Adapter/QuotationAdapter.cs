using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response;
using IMT.Thunes.Route;


namespace IMT.Thunes.Adapter
{
    public class QuotationAdapter : BaseAdapter
    {
        public QuotationAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        public object CreateQuatatioin(CreateQuatationRequest request)
        {
            return RestClient.Post(RequestOptions.BaseUrl + ThunesUrl.CreateQuatationUrl,
                CreateHeaders(request, ThunesUrl.CreateQuatationUrl, RequestOptions), request);
            return result;
        }
        public CreateQuatationResponse GetQuotationById(int id)
        {
            string url = ThunesUrl.RetrieveAQuotationByIdUrl + "/" + id;
            return RestClient.Get(RequestOptions.BaseUrl + url,
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