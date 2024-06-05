
using IMT.PayAll.Net;
using IMT.PayAll.Request;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.PaymentInstructionRequest;
using IMT.PayAll.Response;
using IMT.PayAll.Response.Common;
using IMT.PayAll.Route;


namespace IMT.PayAll.Adapter
{
    public class PaymentInstrumentAdapter : BaseAdapter
    {
        public PaymentInstrumentAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        // Get list of payment instruments
        public PaymentInstrumentsListResponse GetPaymentInstrumentsList(SearchPaymentInstrumentsRequest request)
        {
            var queryParam = RequestQueryParamsBuilder.BuildQueryParam(request);
            var path = PayAllUrl.PaymentInstrumentsList + queryParam;
            return RestClient.Get<PaymentInstrumentsListResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }

        // Create a payment instrument
        public PaymentInstrumentsCreateResponse CreatePaymentInstruments(PaymentInstrumentsRequest request)
        {
            var path = PayAllUrl.CreatePaymentInstruments;
            var paymentInstrumentsRequest = PaymentInstruments(request);
            return RestClient.Post<PaymentInstrumentsCreateResponse>(RequestOptions.BaseUrl + path, CreateHeaders(paymentInstrumentsRequest, path, RequestOptions), paymentInstrumentsRequest);
        }
       

        // Get payment instrument by its ID
        public PaymentInstrumentsResponse GetPaymentInstrumentsByID(string id)
        {
            var path = PayAllUrl.GetPaymentInstrumentsByID + id;
            return RestClient.Get<PaymentInstrumentsResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }

        // Update a payment instrument
        public PaymentInstrumentsResponse UpdatePaymentInstrumentsById(string Id, PaymentInstrumentsRequest request)
        {
            var path = PayAllUrl.UpdatePaymentInstrumentsByID + Id;

            return RestClient.Patch<PaymentInstrumentsResponse>(RequestOptions.BaseUrl + path, CreateHeaders(request, path, RequestOptions), request);
        }

        // Delete a payment instrument
        public string DeletePaymentInstrumentsByID(string id)
        {
            var path = PayAllUrl.DeletePaymentInstrumentsByID + id;
            return RestClient.Delete<string>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }



        private object PaymentInstruments(PaymentInstrumentsRequest request)
        {
            if (request.category == "MobileWallet")
            {
                return new MobileWalletRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    mobile_number = request.mobile_number,
                    recipient_id = request.recipient_id

                };
            }
            if (request.category == "BankAccount")
            {
                return new BankAccountRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    recipient_id = request.recipient_id,
                    account_id = request.account_id,

                };
            }
            if (request.category == "CashPickup")
            {
                return new CashPickupRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    recipient_id = request.recipient_id,
                };
            }
            if (request.category == "Card")
            {
                return new CardRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    recipient_id = request.recipient_id,
                    token = request.token,
                };
            }

            return null;

        }

    }
}