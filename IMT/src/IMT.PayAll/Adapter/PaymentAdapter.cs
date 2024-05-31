
using IMT.PayAll.Net;
using IMT.PayAll.Request;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response;
using IMT.PayAll.Route;


namespace IMT.PayAll.Adapter
{
    public class PaymentAdapter : BaseAdapter
    {
        public PaymentAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        public HttpResponseModel SinglePayment(CreatePaymentRequest createPaymentRequest)
        {
            var path = PayAllUrl.SinglePayment;
            return RestClient.Post(RequestOptions.BaseUrl + path, CreateHeaders(createPaymentRequest, path, RequestOptions), createPaymentRequest);
        }


    }
}