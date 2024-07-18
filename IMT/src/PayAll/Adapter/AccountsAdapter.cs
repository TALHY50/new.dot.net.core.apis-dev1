
using IMT.PayAll.Net;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Response.Payment;
using IMT.PayAll.Route;

namespace IMT.PayAll.Adapter
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
