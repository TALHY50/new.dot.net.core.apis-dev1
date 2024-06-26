//using IMT.Thunes.Adapter;
using IMT.Thunes.Adapter.Account;
using IMT.Thunes.Adapter.Connectivity;
using IMT.Thunes.Adapter.CreditParties;
using IMT.Thunes.Adapter.Discovery;
using IMT.Thunes.Adapter.Transfers.Quotations;
using IMT.Thunes.Adapter.Transfers.Transaction;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Request.Transaction.Transfer;
using IMT.Thunes.Response;

namespace IMT.Thunes
{
    public class ThunesClient
    {
        private const string BaseUrl = "https://xyz";

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
                Language = language
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
