//using Thunes.Adapter;

using Thunes.Adapter.Account;
using Thunes.Adapter.Connectivity;
using Thunes.Adapter.CreditParties;
using Thunes.Adapter.Discovery;
using Thunes.Adapter.Transfers.Quotations;
using Thunes.Adapter.Transfers.Transaction;
using Thunes.Request.Common;

namespace Thunes
{
    public class ThunesClient
    {
        private const string BaseUrl = "https://api-mt.pre.thunes.com";

        private readonly QuotationAdapter _quotationAdapter;
        private readonly InformationAdapter _information_adapter;
        private readonly TransactionAdapter _transactionAdapter;
        private readonly VerificationAdapter _verificationAdapter;
        private readonly AccountAdapter _accountAdapter;
        private readonly ConnectivityAdapter _connectivityAdapter;
        private readonly DiscoveryAdapter _discoveryAdapter;

        public ThunesClient(string apiKey, string secretKey)
            : this(apiKey, secretKey, BaseUrl)
        {
        }

        public ThunesClient(string apiKey, string secretKey, string baseUrl, string? language = null)
        {
            var requestOptions = new RequestOptions
            {
                ApiKey = apiKey,
                SecretKey = secretKey,
                BaseUrl = baseUrl,
                //Language = language
            };
            _quotationAdapter = new QuotationAdapter(requestOptions);
            _information_adapter = new InformationAdapter(requestOptions);
            _transactionAdapter = new TransactionAdapter(requestOptions);
            _verificationAdapter = new VerificationAdapter(requestOptions);
            _accountAdapter = new AccountAdapter(requestOptions);
            _connectivityAdapter = new ConnectivityAdapter(requestOptions);
            _discoveryAdapter = new DiscoveryAdapter(requestOptions);
        }

        public QuotationAdapter QuotationAdapter()
        {
            return _quotationAdapter;
        }

        public InformationAdapter GetInformationAdapter()
        {
            return _information_adapter;
        }

        public TransactionAdapter GetTransactionAdapter()
        {
            return _transactionAdapter;
        }
        public ConnectivityAdapter GetConnectivityAdapter()
        {
            return _connectivityAdapter;
        }

        public VerificationAdapter VerificationAdapter()
        {
            return _verificationAdapter;
        }

        public AccountAdapter GetAccountAdapter()
        {
            return _accountAdapter;
        }

        public DiscoveryAdapter GetDiscoveryAdapter()
        {
            return _discoveryAdapter;
        }


    }
}
