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
        private readonly ThunesClient _thunesClient = new ThunesClient("asdfasdf", "asdfasdf", "http://localhost:3001");

        [Test]
        public void Test1()
        {
            CreateQuatationRequest request = new CreateQuatationRequest();
            var response = _thunesClient.QuotationAdapter().CreateQuatatioin(request);

            Assert.True(true);
        }
    }
}