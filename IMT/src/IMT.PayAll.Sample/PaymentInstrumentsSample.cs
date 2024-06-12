
using IMT.PayAll.Common;
using IMT.PayAll.Request;
using IMT.PayAll.Request.PaymentInstructionUpdateRequest;
using NUnit.Framework;

namespace IMT.PayAll.Sample
{
    public class PaymentInstrumentsSample
    {
        private readonly PayAllClient _payAllClient;
        public PaymentInstrumentsSample()
        {
            var requirement = BaseRequirement.GetBaseRequirement(BaseSample.ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }
        [Test]
        public void PaymentInstrumentsList()
        {
            Guid recipient_id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var request = new SearchPaymentInstrumentsRequest()
            {
                recipient_id = recipient_id
            };
            var result = _payAllClient.PaymentInstruments().GetPaymentInstrumentsList(request);
          
            Assert.NotNull(result);
        }

        [Test]
        public void CreatePaymentInstruments()
        {
            var request = CreatePaymentInstrumentsRequest();
            var result = _payAllClient.PaymentInstruments().CreatePaymentInstruments(request);
            Assert.NotNull(result);
        }

        [Test]
        public void GetPaymentInstrumentsById()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var response = _payAllClient.PaymentInstruments().GetPaymentInstrumentsByID(id);
            Assert.NotNull(response);
        }


        [Test]
        public void UpdatePaymentInstrumentsById()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var request = UpdateModel();
            var result = _payAllClient.PaymentInstruments().UpdatePaymentInstrumentsById(id, request);
            Assert.NotNull(result);
        }

        [Test]
        public void DeletePaymentInstrumentsById()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var result = _payAllClient.PaymentInstruments().DeletePaymentInstrumentsByID(id);
            Assert.Null(result);
        }

        private PaymentInstrumentsRequest CreatePaymentInstrumentsRequest()
        {
            return new PaymentInstrumentsRequest {
                category = "MobileWallet",
                currency = "USD",
                routing_number = "123456789",
                swift_bic_code = "ABCDEF12",
                bank_domestic_code = "123",
                iban = "DE89370400440532013000",
                swift_intermediary = "GHIJKL34",
                routing_number_intermediary = "987654321",
                iban_intermediary = "FR7630006000011234567890189",
                account_id = "acc12345",
                bank_name = "Bank of Example",
                bank_branch_name = "Main Branch",
                bank_country = "US",
                bank_address = "123 Bank Street, City, State, Zip",
                account_number = "000123456789",
                sub_account_number = "001",
                account_type = "Checking",
                account_name = "John Doe",
                urgency_flag_preference = "High",
                first_name = "John",
                last_name = "Doe",
                mobile_number = "123-456-7890",
                recipient_id = "123",
                token = ""
            };

        }
        private PaymentInstrumentsUpdateRequest UpdateModel()
        {
           return new PaymentInstrumentsUpdateRequest
            {
                 category = "MobileWallet",
                  currency = "USD",
                routing_number = "123456789",
                swift_bic_code = "ABCDEF12",
                bank_domestic_code = "123",
                iban = "DE89370400440532013000",
                swift_intermediary = "GHIJKL34",
                routing_number_intermediary = "987654321",
                iban_intermediary = "FR7630006000011234567890189",
                account_id = "acc12345",
                bank_name = "Bank of Example",
                bank_branch_name = "Main Branch",
                bank_country = "US",
                bank_address = "123 Bank Street, City, State, Zip",
                account_number = "000123456789",
                sub_account_number = "001",
                account_type = "Checking",
                account_name = "John Doe",
                urgency_flag_preference = "High",
                first_name = "John",
                last_name = "Doe",
                mobile_number = "123-456-7890"
            };
        }
    }
}