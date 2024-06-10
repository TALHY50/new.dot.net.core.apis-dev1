using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using IMT.Thunes.Request.Transaction.Quoatation;
using NUnit.Framework;

namespace IMT.Thunes.Sample
{
    public class QuatationSample
    {

        private readonly ThunesClient _thunesClient;
        public QuatationSample()
        {
            Env.NoClobber().TraversePath().Load();
            _thunesClient = new ThunesClient(Env.GetString("API_SECRET"), Env.GetString("API_KEY"), Env.GetString("BASE_URL"));
        }

        [Test]
        public void Test1()
        {
            CreateQuatationRequest request = new CreateQuatationRequest();
            var response = _thunesClient.QuotationAdapter().CreateQuatatioin(request);

            Assert.True(true);
        }
    }
}