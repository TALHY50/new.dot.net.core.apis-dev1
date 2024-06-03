//using IMT.Thunes.Adapter;
using IMT.Thunes.Adapter;
using IMT.Thunes.Adapter.CreditParties;
using IMT.Thunes.Request;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response;

namespace IMT.Thunes
{
    public class ThunesClient
    {
        private const string BaseUrl = "https://xyz";

        private readonly QuotationAdapter _quotationAdapter;
        private readonly InformationAdapter _information_adapter;
        private readonly TransactionAdapter _transactionAdapter;

        public ThunesClient(string apiKey, string secretKey)
            : this(apiKey, secretKey, BaseUrl, null)
        {
        }

        public ThunesClient(string apiKey, string secretKey, string baseUrl, string language = null)
        {
            var requestOptions = new RequestOptions
            {
                ApiKey = apiKey,
                SecretKey = secretKey,
                BaseUrl = baseUrl,
                Language = language
            };
            this._quotationAdapter = new QuotationAdapter(requestOptions);
            this._information_adapter = new InformationAdapter(requestOptions);
            _transactionAdapter = new TransactionAdapter(requestOptions);
        }


        public object CreateQuotation(CreateQuatationRequest request)
        {
            return this._information_adapter;
        }

        public object CreateTransaction(CreateNewTransactionRequest request)
        {
            return _transactionAdapter.CreateTransaction(request);
        }


    }
}
