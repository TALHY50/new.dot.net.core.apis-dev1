
using IMT.PayAll.Common;
using NUnit.Framework;

namespace IMT.PayAll.Sample
{
    public class AccountSample
    {
        private readonly PayAllClient _payAllClient;
        public AccountSample()
        {
            var requirement = BaseRequirement.GetBaseRequirement(BaseSample.ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }
        [Test]
        public void GetPaymentAccountsList()
        {
            var result = _payAllClient.Accounts().GetPaymentAccountsList();
            Assert.NotNull(result);
        }
    }
}