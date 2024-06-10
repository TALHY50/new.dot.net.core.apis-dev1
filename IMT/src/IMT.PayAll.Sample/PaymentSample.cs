using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using NUnit.Framework;

namespace IMT.PayAll.Sample
{
    public class PaymentSample
    {
        public PaymentSample() {
            Env.NoClobber().TraversePath().Load();
            var s = Env.GetString("THUNES_API_SECRET");
            var data = "";       
        }
        [Test]
        public void Test1()
        {
            Assert.True(true);
        }
    }
}