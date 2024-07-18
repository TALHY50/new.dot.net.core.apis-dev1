using PayAll.Net;
using PayAll.Request.Common;
using PayAll.Response.Payment;
using PayAll.Route;

namespace PayAll.Adapter
{
    public class AccountsAdapter : BaseAdapter
    {
        public AccountsAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        // Get list of payment accounts
        public IEnumerable<PaymentAccountResponse> GetPaymentAccountsList()
        {
            var path = PayAllUrl.GetPaymentAccountsList;

            return RestClient.Get<IEnumerable<PaymentAccountResponse>>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));

        }
    }
}
