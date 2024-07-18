using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.Transaction.Transfer;
using IMT.Thunes.Response.Connectivity.Ping;
using IMT.Thunes.Response.Transfer.Transaction;
using IMT.Thunes.Route;

namespace IMT.Thunes.Adapter.Connectivity
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
