//using IMT.Thunes.Adapter;
using IMT.Thunes.Request.Common;

namespace IMT.Thunes
{
    public class ThunesClient
    {
        private const string BaseUrl = "https://xyz";
        public ThunesClient(string apiKey, string secretKey)
            : this(apiKey, secretKey, BaseUrl, null)
        {
        }

        public ThunesClient(string apiKey, string secretKey, string baseUrl, string language)
        {
            var requestOptions = new RequestOptions
            {
                ApiKey = apiKey,
                SecretKey = secretKey,
                BaseUrl = baseUrl,
                Language = language
            };
        }
    }
}
