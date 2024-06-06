using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response.Balances;
using IMT.Thunes.Route;

namespace IMT.Thunes.Adapter.Account
{
    public class AccountAdapter : BaseAdapter
    {
        public AccountAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        public List<BalanceResponse> GetBalanceResponse()
        {
            string url = ThunesUrl.BalancesUrl;
            return RestClient.Get<List<BalanceResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

    }
}