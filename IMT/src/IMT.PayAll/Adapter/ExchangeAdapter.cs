
using IMT.PayAll.Net;
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

    }
}