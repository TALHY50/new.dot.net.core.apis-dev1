//using IMT.Thunes.Adapter;
using IMT.Thunes.Adapter;
using IMT.Thunes.Request;
using IMT.Thunes.Request.Common;
using IMT.Thunes.Response;

namespace IMT.Thunes
{
    public class ThunesClient
    {
        private const string BaseUrl = "https://xyz";

        private readonly QuotationAdapter _quotationAdapter;
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
            _transactionAdapter = new TransactionAdapter(requestOptions);
        }


        public object CreateQuotation(CreateQuatationRequest request)
        {
            return this._quotationAdapter;
        }

        public object CreateTransaction(CreateNewTransactionRequest request)
        {
            return _transactionAdapter.CreateTransaction(request);
        }


    }
}
