
using IMT.PayAll;
using IMT.PayAll.Request;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayAllController : ControllerBase
    {
        private readonly PayAllClient _payAllClient;
        public PayAllController()
        {
            _payAllClient = new PayAllClient("api-key", "secret-key", "https://api.sandbox.payall.com");
        }
        [HttpPost(Name = "Payment")]
        public string Get()
        {
            var request = CreatePaymentRequest();
            var response = _payAllClient.Payment().Initiate_single_payment(request);

            return response;
        }

        private CreatePaymentRequest CreatePaymentRequest()
        {
            var paymentData = new CreatePaymentRequest
            {
                ClientPaymentId = "string",
                Recipient = new Recipient
                {
                    Email = "user@example.com",
                    FirstName = "string",
                    LastName = "string",
                    MiddleName = "string",
                    MobileNumber = "string",
                    Dob = new DateTime(2024, 5, 30),
                    RegistrationAddress = new List<RegistrationAddress>
                {
                    new RegistrationAddress
                    {
                        City = "string",
                        Street = "string",
                        Country = "string",
                        PostalCode = "string",
                        UnitNumber = "string",
                        BuildingName = "string",
                        StateProvince = "string",
                        BuildingNumber = "string"
                    }
                },
                    IdentityDocument = new IdentityDocument
                    {
                        Type = "string",
                        TypeVersionNumber = "string",
                        CountryIssuing = "string",
                        Number = "string",
                        NationalIdNumber = "string",
                        NationalIdNumberType = "string",
                        Series = "string",
                        IssueDate = DateTime.Parse("2024-05-30T10:28:20.751Z"),
                        PlaceOfIssue = "string",
                        AuthorityOfIssue = "string",
                        ExpiryDate = DateTime.Parse("2024-05-30T10:28:20.751Z"),
                        DriverLicenseNumber = "string",
                        DriverLicenseSerialNumber = "string",
                        DriverLicenseVersionNumber = "string"
                    }
                },
                PaymentInstrument = new PaymentInstrument
                {
                    Category = "MobileWallet",
                    Currency = "string",
                    MobileNumber = "string"
                },
                RecipientId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                PaymentInstrumentId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                SourceAccountId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                Amount = new Amount
                {
                    Currency = "EUR",
                    Value = 10023
                },
                ExchangeRateId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                CardedRateId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                KYT = new KYT
                {
                    DestinationCountry = "GB",
                    PaymentPurpose = "family_maintenance",
                    CommercialActivity = "transportation",
                    PaymentDescription = "string",
                    SupportingDocuments = new List<SupportingDocument>
                {
                    new SupportingDocument
                    {
                        DocumentId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
                    }
                }
                }
            };
            return paymentData;
        }
    }
}
