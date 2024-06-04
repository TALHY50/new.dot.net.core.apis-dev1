
using IMT.PayAll.Net;
using IMT.PayAll.Request;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response;
using IMT.PayAll.Response.Common;
using IMT.PayAll.Route;


namespace IMT.PayAll.Adapter
{
    public class PaymentAdapter : BaseAdapter
    {
        public PaymentAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        // Initiate a single payment
        public HttpResponse<PaymentResponse> SinglePayment(CreatePaymentRequest createPaymentRequest)
        {
            var path = PayAllUrl.SinglePayment;
            return RestClient.Post<PaymentResponse>(RequestOptions.BaseUrl + path, CreateHeaders(createPaymentRequest, path, RequestOptions), createPaymentRequest);
        }

        // Get payment information by its ID
        public HttpResponse<PaymentInformationResponse> GetPaymentById(string Id)
        {
            var path = PayAllUrl.GetPaymentById + Id;
         
            return RestClient.Get<PaymentInformationResponse>(RequestOptions.BaseUrl + path,CreateHeaders(path, RequestOptions));
        }

        // Update payment details
        public HttpResponse<PaymentUpdateRequest> UpdatePaymentDetailsById(string Id, PaymentUpdateRequest request)
        {
            var path = PayAllUrl.UpdatePaymentById + Id;

            return RestClient.Patch<PaymentUpdateRequest>(RequestOptions.BaseUrl + path, CreateHeaders(request, path, RequestOptions), request);
        }


    }
}