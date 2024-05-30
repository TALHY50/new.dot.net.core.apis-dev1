
using IMT.PayAll.Net;
using IMT.PayAll.Request;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response;
using Newtonsoft.Json;


namespace IMT.PayAll.Adapter
{
    public class PaymentAdapter : BaseAdapter
    {
        string barier = "afkljfkkdfjkdsfakjsfksdf";
        public PaymentAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        public string Initiate_single_payment(CreatePaymentRequest createPaymentRequest)
        {
             var path = "/v2/single-payment";
             var data = JsonConvert.SerializeObject(createPaymentRequest, Formatting.Indented);
             var result = RestClient.Post<PaymentResponse>(RequestOptions.BaseUrl + path, barier, data);
             return result;
        }


    }
}