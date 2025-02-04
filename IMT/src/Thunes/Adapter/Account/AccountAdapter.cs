using Thunes.Net;
using Thunes.Request.Common;
using Thunes.Response.Account;
using Thunes.Route;

namespace Thunes.Adapter.Account
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

        public List<BalanceMovementResponse> GetBalanceMovement(uint id, DateTime from_date, DateTime to_date, string queryParams = null)
        {
            string url = ThunesUrl.BalanceMovementUrl.Replace("{id}", id.ToString());
            url = url + "?from_date=" + from_date.ToString("yyyy-MM-ddTHH:mm:ssZ") + "&to_date=" + to_date.ToString("yyyy-MM-ddTHH:mm:ssZ") + "&" + queryParams;
            return RestClient.Get<List<BalanceMovementResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public List<ListReportsAvailableResponse> ListReportsAvailable(string queryParams = null)
        {
            string url = ThunesUrl.ListReportsAvailableUrl + queryParams;
            return RestClient.Get<List<ListReportsAvailableResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public ListReportsAvailableResponse GetReportDetail(uint id)
        {
            string url = ThunesUrl.GetReportDetailUrl.Replace("{id}", id.ToString());
            return RestClient.Get<ListReportsAvailableResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public List<ListReportFilesAvailableResponse> ListReportsAvailable(uint id)
        {
            string url = ThunesUrl.ListReportFilesAvailableUrl.Replace("{id}", id.ToString());
            return RestClient.Get<List<ListReportFilesAvailableResponse>>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

        public ReportFileDetailsResponse GetReportFileDetails(uint report_id, uint id)
        {
            string url = ThunesUrl.ReportFileDetailUrl.Replace("{report_id}", report_id.ToString()).Replace("{id}", id.ToString());
            return RestClient.Get<ReportFileDetailsResponse>(RequestOptions.BaseUrl + url,
                CreateHeaders(url, RequestOptions));
        }

    }
}