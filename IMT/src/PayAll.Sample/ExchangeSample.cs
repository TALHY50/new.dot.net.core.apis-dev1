
using IMT.PayAll.Common;
using IMT.PayAll.Model;
using IMT.PayAll.Request.Exchange;
using IMT.PayAll.Response.Common;
using NUnit.Framework;

namespace IMT.PayAll.Sample
{
    public class ExchangeSample
    {
        private readonly PayAllClient _payAllClient;
        public ExchangeSample()
        {
            var requirement = BaseRequirement.GetBaseRequirement(BaseSample.ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }


        [Test]
        public void GetExchangeRateById()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var result = _payAllClient.Exchanges().GetExchangeRateByID(id);
            Assert.NotNull(result);
        }

        [Test]
        public void GetNewRateByExistRateId()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var result = _payAllClient.Exchanges().GetNewRateByExistRateID(id);
            Assert.NotNull(result);
        }

        [Test]
        public void RequestExchangeRate()
        {
            var request = RequestData();
            var result = _payAllClient.Exchanges().RequestExchangeRate(request);
            Assert.NotNull(result);
        }

        [Test]
        public void ConfirmExchangeRate()
        {
            var request = ConfirmExchangeRateRequest();
            var result = _payAllClient.Exchanges().ConfirmExchangeRate(request);
            Assert.Null(result);
        }

       [Test]
        public void CancelExchangeRate()
        {
            var request = CancelExchangeRateRequest();
            var result = _payAllClient.Exchanges().CancelExchangeRate(request);
            Assert.Null(result);
        }

        [Test]
        public void GetCardedExchangeRate()
        {
            var result = _payAllClient.Exchanges().GetCardedExchangeRate();
            Assert.NotNull(result);
        }

        private RequestExchangeRate RequestData()
        {
            return new RequestExchangeRate
            {
                source_amount = new SourceAmount
                {
                     currency = Currency.USD.ToString(),
                      value = 123
                },
                target_amount = new TargetAmount
                {
                    currency = Currency.USD.ToString(),
                    value = 123
                },
                source_account_id = "acc12345",
                source_currency = Currency.USD.ToString(),
                recipient_instrument_id = "recip67890",
                payment_instrument_category = PaymentInstrumentCategory.MobileWallet.ToString(),
                payment_type = PaymentType.B2B.ToString(),
                target_currency = Currency.USD.ToString(),
                destination_country = "DE"
            };
        }

        private ConfirmExchangeRateRequest ConfirmExchangeRateRequest()
        {
            return new ConfirmExchangeRateRequest { exchange_rate_id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") };
        }
        private CancelExchangeRateRequest CancelExchangeRateRequest()
        {
            return new CancelExchangeRateRequest { exchange_rate_id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") };
        }
    }
}