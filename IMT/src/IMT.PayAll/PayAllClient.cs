using IMT.PayAll.Adapter;
using IMT.PayAll.Request.Common;

namespace IMT.PayAll
{
    public class PayAllClient
    {
        private const string BaseUrl = "https://api.sandbox.payall.com";
        private readonly PaymentAdapter _paymentAdapter;
       
        public PayAllClient(string apiKey, string secretKey)
            : this(apiKey, secretKey, BaseUrl, null)
        {
        }

        public PayAllClient(string apiKey, string secretKey, string baseUrl)
            : this(apiKey, secretKey, baseUrl, null)
        {
        }

        public PayAllClient(string apiKey, string secretKey, string baseUrl, string language)
        {
            var requestOptions = new RequestOptions
            {
                ApiKey = apiKey,
                SecretKey = secretKey,
                BaseUrl = baseUrl,
                Language = language
            };

            _paymentAdapter = new PaymentAdapter(requestOptions);

        }

        public PaymentAdapter Payment()
        {
            return _paymentAdapter;
        }

    
    }
}
