using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using IMT.Thunes.Request.Transaction.Quoatation;
using NUnit.Framework;

namespace IMT.Thunes.Sample
{
    public class ThunesSample
    {

        private readonly ThunesClient _thunesClient;
        public ThunesSample()
        {
            Env.NoClobber().TraversePath().Load();
            string apiSecret = Env.GetString("API_SECRET");
            string apiKey = Env.GetString("API_KEY");
            string baseUrl = Env.GetString("BASE_URL");
            _thunesClient = new ThunesClient(apiSecret, apiKey, baseUrl);
        }

        [Test]
        public void CreateQuatatioin()
        {
            CreateQuatationRequest request = new CreateQuatationRequest();
            var response = _thunesClient.QuotationAdapter().CreateQuatatioin(request);
            Assert.NotNull(response);
        }

        [Test]
        public void CreateQGetQuotationByIduatatioin()
        {
            int id = 1;
            var response = _thunesClient.QuotationAdapter().GetQuotationById(id);
            Assert.NotNull(response);
        }

        [Test]
        public void GetRetrieveQuotationByExternalId()
        {
            ulong id = 1234;
            var response = _thunesClient.QuotationAdapter().GetRetrieveQuotationByExternalId(id);
            Assert.NotNull(response);
        }
    }
}