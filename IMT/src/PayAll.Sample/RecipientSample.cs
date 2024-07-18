
using IMT.PayAll.Common;
using IMT.PayAll.Model;
using IMT.PayAll.Request.PaymentRequest;
using IMT.PayAll.Request.Recipient;
using NUnit.Framework;

namespace IMT.PayAll.Sample
{
    public class RecipientSample
    {
        private readonly PayAllClient _payAllClient;
        public RecipientSample()
        {
            var requirement = BaseRequirement.GetBaseRequirement(BaseSample.ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }

        [Test]
        public void GetRecipients()
        {
            var result = _payAllClient.Recipients().GetRecipients();
            Assert.NotNull(result);
        }

        [Test]
        public void CreateRecipients()
        {
            var request = RecipientRequestData();
            var result = _payAllClient.Recipients().CreateRecipient(request);
            Assert.NotNull(result);
        }

        [Test]
        public void UpdateRecipient()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var request = RecipientRequestData();
            var result = _payAllClient.Recipients().UpdateRecipient(id, request);
            Assert.NotNull(result);
        }

        [Test]
        public void DeleteRecipient()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var result = _payAllClient.Recipients().DeleteRecipient(id);
            Assert.Null(result);
        }

        private RecipientRequest RecipientRequestData()
        {
            var identityDocument = new IdentityDocumentRequest
            {
                 type = "Passport",
                 type_version_number = "V1",
                 country_issuing = "US",
                 number = "123456789",
                national_id_number = "987654321",
                national_id_number_type = "SSN",
                series = "AB",
                issue_date = new DateTime(2020, 1, 1),
                place_of_issue = "New York",
                authority_of_issue = "State Department",
                expiry_date = new DateTime(2030, 1, 1),
                driver_license_number = "D1234567",
                driver_license_serial_number = "S1234567",
                driver_license_version_number = "1"
            };

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

            return new RecipientRequest
            {
                type = AccountType.Person.ToString(),
                email = "john.doe@example.com",
                registration_address = new List<RegistrationAddressRequest> { registrationAddress },
                first_name = "John",
                last_name = "Doe",
                middle_name = "A",
                mobile_number = "123-456-7890",
                dob = new DateOnly(1985, 5, 15),
                legal_name = "John A. Doe",
                country = "US",
                trade_name = "JD Enterprises",
                phone_number = "098-765-4321",
                registration_number = "RN123456",
                identity_document = identityDocument
            };
        }
    }
}