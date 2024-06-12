
using IMT.PayAll.Common;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.PaymentRequest;
using NUnit.Framework;
using IMT.PayAll.Request.Payment;

namespace IMT.PayAll.Sample
{
    public class PaymentSample
    {
        private readonly PayAllClient _payAllClient;
        public PaymentSample()
        {
            var requirement = BaseRequirement.GetBaseRequirement(BaseSample.ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }
        [Test]
        public void SinglePayment()
        {
            var request = CreatePaymentRequest();
            var response = _payAllClient.Payment().SinglePayment(request);
            Assert.NotNull(response);
        }

        [Test]
        public void GetPaymentById()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var response = _payAllClient.Payment().GetPaymentById(id);
            Assert.NotNull(response);
        }

        [Test]
        public void UpdatePaymentById()
        {
            Guid id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var request = PaymentUpdateRequest();
            var response = _payAllClient.Payment().UpdatePaymentDetailsById(id,request);
            Assert.NotNull(response);
        }


        private CreatePaymentRequest CreatePaymentRequest()
        {

            var paymentData = new CreatePaymentRequest
            {
                client_payment_id = "CP12345",

                /*
                recipient = new RecipientRequest()
                {
                    type = "Business",
                    email = "john.doe@example.com",
                    first_name = "John",
                    last_name = "Doe",
                    middle_name = "A",
                    mobile_number = "+123456789",
                    dob = new DateOnly(),
                    registration_address = new List<RegistrationAddressRequest>
                {
                    new RegistrationAddressRequest
                    {
                        city = "New York",
                        street = "5th Avenue",
                        country = "USA",
                        postal_code = "10001",
                        unit_number = "1A",
                        building_name = "Empire State Building",
                        state_province = "NY",
                        building_number = "350"
                    }
                },
                    identity_document = new IdentityDocumentRequest
                    {
                        type = "Passport",
                        type_version_number = "1.0",
                        country_issuing = "USA",
                        number = "123456789",
                        national_id_number = "987654321",
                        national_id_number_type = "SSN",
                        series = "AB",
                        issue_date = new DateTime(2020, 1, 1),
                        place_of_issue = "New York",
                        authority_of_issue = "US Department of State",
                        expiry_date = new DateTime(2030, 1, 1),
                        driver_license_number = "D1234567",
                        driver_license_serial_number = "DL1234",
                        driver_license_version_number = "1"
                    }
                },
                */

                /*
                payment_instrument = new PaymentInstrumentRequest
                {
                    category = "Credit Card",
                    currency = "USD",
                    mobile_number = "+123456789"
                },*/

                recipient_id = "R12345",
                payment_instrument_id = "PI12345",
                source_account_id = "SA12345",
                amount = new Amount
                {
                    currency = "USD",
                    value = 1000
                },
                exchange_rate_id = "ER12345",
                carded_rate_id = "CR12345",
                kyt = new KytRequest
                {
                    destination_country = "USA",
                    payment_purpose = "Business",
                    commercial_activity = "IT Services",
                    payment_description = "Invoice Payment",
                    supporting_documents = new List<SupportingDocument>
                {
                    new SupportingDocument
                    {
                        document_id = "SD12345"
                    }
                }
                }
            };
            return paymentData;
        }

        private PaymentUpdateRequest PaymentUpdateRequest()
        {
            return new PaymentUpdateRequest
            {
                supporting_documents = new List<SupportingDocument>{
                                        new SupportingDocument { document_id = "3fa85f64-5717-4562-b3fc-2c963f66afa6" }
            },
                exchange_rate_id = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
        }
    }

}