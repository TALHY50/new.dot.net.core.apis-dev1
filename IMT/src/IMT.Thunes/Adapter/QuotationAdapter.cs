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

        public BaseCreateQuatationResponse createQuatatioin(CreateQuatationRequest request)
        {
            // return new BaseCreateQuatationResponse();
            return RestClient.Post<BaseCreateQuatationResponse>(RequestOptions.BaseUrl + ThunesUrl.CreateQuatationUrl,
                CreateHeaders(request, ThunesUrl.CreateQuatationUrl, RequestOptions), request);
        }
    }
}