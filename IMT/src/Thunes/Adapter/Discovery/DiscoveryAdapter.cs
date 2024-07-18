using Thunes.Net;
using Thunes.Request.Common;
using Thunes.Response.Discovery;
using Thunes.Route;

namespace Thunes.Adapter.Discovery
{
    public class DiscoveryAdapter : BaseAdapter
    {
        public DiscoveryAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }
        public List<ServiceResponse> ServiceResponse(string query = null)
        {
            string url = ThunesUrl.ListServicesAvailableUrl + query;
            return RestClient.Get<List<ServiceResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public List<PayerResponse> PayerResponse(string query = null)
        {
            string url = ThunesUrl.ListPayersAvailableUrl + query;
            return RestClient.Get<List<PayerResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public PayerResponse PayerResponseDetails(ulong id)
        {
            string url = ThunesUrl.GetPayerDetailUrl.Replace("{id}", id.ToString());
            return RestClient.Get<PayerResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public PayerRateResponse PayerRateResponse(ulong id)
        {
            string url = ThunesUrl.RetrieveRatesForAGivenPayerUrl.Replace("{id}", id.ToString());
            return RestClient.Get<PayerRateResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public List<CountryResponse> CountryResponse(string query = null)
        {
            string url = ThunesUrl.ListCountriesAvailableUrl + query;
            return RestClient.Get<List<CountryResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public List<LookupResponse> LookupResponse(string swift_bic_code, string query = null)
        {
            string url = ThunesUrl.BicCodeLookupUrl.Replace("{swift_bic_code}", swift_bic_code.ToString()) + query;
            return RestClient.Get<List<LookupResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }
    }
}