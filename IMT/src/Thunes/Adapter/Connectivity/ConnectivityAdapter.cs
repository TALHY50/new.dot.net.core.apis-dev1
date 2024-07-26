using Thunes.Net;
using Thunes.Request.Common;
using Thunes.Response.Connectivity.Ping;
using Thunes.Route;

namespace Thunes.Adapter.Connectivity
{
    public class ConnectivityAdapter :BaseAdapter
    {
        public ConnectivityAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        public object Ping()
        {
            var url = ThunesUrl.ConnectivityUrl;
            return RestClient.Get<PingResponse>(RequestOptions.BaseUrl + url, CreateHeaders( url, RequestOptions));
        }
    }
}
