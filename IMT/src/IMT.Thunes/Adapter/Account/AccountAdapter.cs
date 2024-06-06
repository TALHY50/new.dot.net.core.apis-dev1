using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Thunes.Net;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response.Account;
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

        public List<BalanceMovementResponse> GetBalanceMovement(ulong id, DateTime from_date, DateTime to_date, string queryParams = null)
        {
            string url = ThunesUrl.BalanceMovementUrl.Replace("{id}", id.ToString());
            url = url + "?from_date=" + from_date + "&to_date=" + to_date + "&" + queryParams;
            return RestClient.Get<List<BalanceMovementResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public List<ListReportsAvailableResponse> ListReportsAvailable(string queryParams = null)
        {
            string url = ThunesUrl.ListReportsAvailableUrl + queryParams;
            return RestClient.Get<List<ListReportsAvailableResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public ListReportsAvailableResponse GetReportDetail(ulong id)
        {
            string url = ThunesUrl.GetReportDetailUrl.Replace("{id}", id.ToString());
            return RestClient.Get<ListReportsAvailableResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public List<ListReportFilesAvailableResponse> ListReportsAvailable(ulong id)
        {
            string url = ThunesUrl.ListReportFilesAvailableUrl.Replace("{id}", id.ToString());
            return RestClient.Get<List<ListReportFilesAvailableResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

    }
}