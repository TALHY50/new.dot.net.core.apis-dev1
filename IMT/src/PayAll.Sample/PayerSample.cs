using NUnit.Framework;
using PayAll.Common;
using PayAll.Model;
using PayAll.Request.Payer;
using PayAll.Request.PaymentRequest;

namespace PayAll.Sample
{
    public class PayerSample
    {
        private readonly PayAllClient _payAllClient;
        public PayerSample()
        {
            var requirement = BaseRequirement.GetBaseRequirement(BaseSample.ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }

        [Test]
        public void GetPayers()
        {
            var result = _payAllClient.Payers().GetPayers();
            Assert.NotNull(result);
        }

        [Test]
        public void CreatePayers()
        {
            var request = PayerRequestData();
            var result = _payAllClient.Payers().CreatePayers(request);
            Assert.NotNull(result);

        }

        [Test]
        public void GetPayer()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var result = _payAllClient.Payers().GetPayerByID(id);
            Assert.NotNull(result);
        }

        [Test]
        public void GetPayerAccounts()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var result = _payAllClient.Payers().GetPayerAccounts(id);
            Assert.NotNull(result);
        }

        private PayerRequest PayerRequestData()
        {

            var registrationAddress = new RegistrationAddressRequest
            {
                city = "New York",
                street = "5th Avenue",
                country = "US",
                postal_code = "10001",
                unit_number = "10B",
                building_name = "Empire State Building",
                state_province = "NY",
                building_number = "350"
            };

            return new PayerRequest
            {
                type = AccountType.Person.ToString(),
                email = "john.doe@example.com",
                registration_address = new List<RegistrationAddressRequest> { registrationAddress },
                first_name = "John",
                last_name = "Doe",
                middle_name = "A",
                date_of_birth = new DateOnly(1985, 5, 15),
                government_id = "123-456-7890",
                nationality = "",
                legal_name = "John A. Doe",
                country = "US",
                trade_name = "JD Enterprises",
                phone_number = "098-765-4321",
                registration_number = "RN123456",
                source_of_income = "",
                occupation = "",
                place_of_birth = "",
                registration_date = new DateOnly(2024, 5, 15),
                relationship_with_beneficiary = ""
            };
        }
    }
}