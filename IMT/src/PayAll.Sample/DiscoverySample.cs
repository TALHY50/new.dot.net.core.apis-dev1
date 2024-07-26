using NUnit.Framework;
using PayAll.Common;

namespace PayAll.Sample
{
    public class DiscoverySample
    {
        private readonly PayAllClient _payAllClient;
        public DiscoverySample()
        {
            var requirement = BaseRequirement.GetBaseRequirement(BaseSample.ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }

        [Test]
        public void GetRequiredPaymentFields()
        {
            var result = _payAllClient.Discovery().GetRequiredPaymentFields();
            Assert.NotNull(result);
        }


    }
}