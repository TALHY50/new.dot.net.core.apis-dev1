
using IMT.PayAll.Net;
using IMT.PayAll.Request;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response;
using IMT.PayAll.Route;


namespace IMT.PayAll.Adapter
{
    public class ExchangeAdapter : BaseAdapter
    {
        public ExchangeAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        // Get exchange rate information by its ID
        public ExchangeResponse GetExchangeRateByID(string Id)
        {
            var path = PayAllUrl.GetExchangeRateByID.Replace("{id}", Id);

            return RestClient.Get<ExchangeResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));

        }

        // Get new exchange rate based on already existing rate.
        public ExchangeResponse GetNewRateByExistRateID(string Id)
        {

            var path = PayAllUrl.GetNewRateByExistRateID.Replace("{id}", Id);

            return RestClient.Get<ExchangeResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));

        }

        // Request exchange rate information.
        public ExchangeResponse RequestExchangeRate(RequestExchangeRate request)
        {

            var path = PayAllUrl.RequestExchangeRate;
            return RestClient.Post<ExchangeResponse>(RequestOptions.BaseUrl + path, CreateHeaders(request, path, RequestOptions), request);
        }

        // Confirm exchange rate
        public string ConfirmExchangeRate(ConfirmExchangeRateRequest request)
        {
            var path = PayAllUrl.ConfirmExchangeRate;
            return RestClient.Post<string>(RequestOptions.BaseUrl + path, CreateHeaders(request, path, RequestOptions), request);
        }

        // Cancel exchange rate
        public string CancelExchangeRate(CancelExchangeRateRequest request)
        {
            var path = PayAllUrl.CancelExchangeRate;
            return RestClient.Post<string>(RequestOptions.BaseUrl + path, CreateHeaders(request, path, RequestOptions), request);
        }

        // Get carded exchange rates
        public GetCardedExchangeRateResponse GetCardedExchangeRate()
        {

            var path = PayAllUrl.GetCardedExchangeRate;

            return RestClient.Get<GetCardedExchangeRateResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));

        }

        // Post carded exchange rates
        public string PostCardedExchangeRate(string event_type, string tenant_id, CardedExchangeRateRequest request)
        {
            RequestOptions.BaseUrl = "https://callbacks.example.com";
            var path = PayAllUrl.PostCardedExchangeRate.Replace("{event_type}", event_type).Replace("{tenant_id}", tenant_id);
            return RestClient.Post<string>(RequestOptions.BaseUrl + path, CreateHeadersForEvent(request, path, RequestOptions), request);
        }
    }
}