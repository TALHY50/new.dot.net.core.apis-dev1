
using IMT.PayAll;
using IMT.PayAll.Common;
using IMT.PayAll.Exception;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.Exchange;
using IMT.PayAll.Request.Payer;
using IMT.PayAll.Request.Payment;
using IMT.PayAll.Request.PaymentInstructionRequest;
using IMT.PayAll.Request.PaymentInstructionUpdateRequest;
using IMT.PayAll.Request.PaymentRequest;
using IMT.PayAll.Request.Recipient;
using IMT.PayAll.Route;
using Microsoft.AspNetCore.Mvc;



namespace IMT.Web.Controllers
{
    [ApiController]
    [Tags("PayAll")]
    [Route("[controller]")]
    public class PayAllController : ControllerBase
    {
        private readonly PayAllClient _payAllClient;

        private string ServerEnvironment = BaseRequirement.Servers.Sandbox.ToString();
        public PayAllController()
        {
            var requirement = BaseRequirement.GetBaseRequirement(ServerEnvironment);
            _payAllClient = new PayAllClient(requirement.ClientID, requirement.ClientSecret, requirement.BaseUrl);
        }
        [Tags("PayAll.Payment")]
        [HttpPost(PayAllUrl.SinglePayment)]
        public object SinglePayment(CreatePaymentRequest request)
        {
            return _payAllClient.Payment().SinglePayment(request);
        }

        [Tags("PayAll.Payment")]
        [HttpGet(PayAllUrl.GetPaymentById)]
        public object GetPaymentById(Guid id)
        {
            var result = _payAllClient.Payment().GetPaymentById(id);
            return Ok(result);
        }

        [Tags("PayAll.Payment")]
        [HttpPatch(PayAllUrl.UpdatePaymentById)]
        public object UpdatePaymentById(Guid id, PaymentUpdateRequest requests)
        {
            var request = UpdatePaymentRequest();
            var result = _payAllClient.Payment().UpdatePaymentDetailsById(id, request);
            return Ok(result);
        }

        [Tags("PayAll.Payment Instruments")]
        [HttpGet(PayAllUrl.PaymentInstrumentsList)]
        public object PaymentInstrumentsList(Guid? recipient_id)
        {
            var request = new SearchPaymentInstrumentsRequest()
            {
                recipient_id = recipient_id
            };
            var result = _payAllClient.PaymentInstruments().GetPaymentInstrumentsList(request);
            return Ok(result);
        }

        [Tags("PayAll.Payment Instruments")]
        [HttpPost(PayAllUrl.CreatePaymentInstruments)]
        public object PaymentInstrumentsCreate(PaymentInstrumentsRequest requests)
        {
            var request = CreatePaymentInstrumentsRequest();
            var result = _payAllClient.PaymentInstruments().CreatePaymentInstruments(requests);
            return Ok(result);
        }

        [Tags("PayAll.Payment Instruments")]
        [HttpGet(PayAllUrl.GetPaymentInstrumentsByID)]
        public object GetPaymentInstrumentsById(Guid id)
        {
            var result = _payAllClient.PaymentInstruments().GetPaymentInstrumentsByID(id);
            return Ok(result);
        }

        [Tags("PayAll.Payment Instruments")]
        [HttpPatch(PayAllUrl.UpdatePaymentInstrumentsByID)]
        public object UpdatePaymentInstrumentsByID(Guid id, PaymentInstrumentsUpdateRequest request)
        {
            var result = _payAllClient.PaymentInstruments().UpdatePaymentInstrumentsById(id, request);
            return Ok(result);
        }


        [Tags("PayAll.Payment Instruments")]
        [HttpDelete(PayAllUrl.DeletePaymentInstrumentsByID)]
        public object DeletePaymentInstrumentsById(Guid id)
        {
            var result = _payAllClient.PaymentInstruments().DeletePaymentInstrumentsByID(id);
            return Ok(result);
        }

        [Tags("PayAll.Exchange")]
        [HttpGet(PayAllUrl.GetExchangeRateByID)]
        public object GetExchangeRateById(Guid id)
        {
            var result = _payAllClient.Exchanges().GetExchangeRateByID(id);
            return Ok(result);
        }

        [Tags("PayAll.Exchange")]
        [HttpGet(PayAllUrl.GetNewRateByExistRateID)]
        public object GetNewRateByExistRateId(Guid id)
        {
            var result = _payAllClient.Exchanges().GetNewRateByExistRateID(id);
            return Ok(result);
        }

        [Tags("PayAll.Exchange")]
        [HttpPost(PayAllUrl.RequestExchangeRate)]
        public object RequestExchangeRate(RequestExchangeRate request)
        {
            var result = _payAllClient.Exchanges().RequestExchangeRate(request);
            return Ok(result);
        }

        [Tags("PayAll.Exchange")]
        [HttpPost(PayAllUrl.ConfirmExchangeRate)]
        public object ConfirmExchangeRate(ConfirmExchangeRateRequest request)
        {
            var result = _payAllClient.Exchanges().ConfirmExchangeRate(request);
            return Ok(result);
        }

        [Tags("PayAll.Exchange")]
        [HttpPost(PayAllUrl.CancelExchangeRate)]
        public object CancelExchangeRate(CancelExchangeRateRequest request)
        {
            var result = _payAllClient.Exchanges().CancelExchangeRate(request);
            return Ok(result);
        }
        [Tags("PayAll.Exchange")]
        [HttpGet(PayAllUrl.GetCardedExchangeRate)]
        public object GetCardedExchangeRate()
        {
            var result = _payAllClient.Exchanges().GetCardedExchangeRate();
            return Ok(result);
        }

        [Tags("PayAll.Accounts")]
        [HttpGet(PayAllUrl.GetPaymentAccountsList)]
        public object GetPaymentAccountsList()
        {
            var result = _payAllClient.Accounts().GetPaymentAccountsList();
            return Ok(result);
        }

        [Tags("PayAll.Recipients")]
        [HttpGet(PayAllUrl.GetRecipientList)]
        public object GetRecipients()
        {
            var result = _payAllClient.Recipients().GetRecipients();
            return Ok(result);
        }

        [Tags("PayAll.Recipients")]
        [HttpPost(PayAllUrl.CreateRecipient)]
        public object CreateRecipients(RecipientRequest requests)
        {
            try
            {
                var result = _payAllClient.Recipients().CreateRecipient(requests);
                return Ok(result);
            }
            catch (ValidationsException ex)
            {
                var validationErrors = new Dictionary<string, string>();
                foreach (var error in ex.ValidationErrors)
                {
                    validationErrors[error.Key] = string.Join("; ", error.Value);
                }
                return BadRequest(validationErrors);
            }
           
        }

        [Tags("PayAll.Recipients")]
        [HttpPatch(PayAllUrl.UpdateRecipient)]
        public object UpdateRecipient(Guid id, RecipientRequest request)
        {
          
            try
            {
                var result = _payAllClient.Recipients().UpdateRecipient(id, request);
                return Ok(result);
            }
            catch (ValidationsException ex)
            {
                var validationErrors = new Dictionary<string, string>();
                foreach (var error in ex.ValidationErrors)
                {
                    validationErrors[error.Key] = string.Join("; ", error.Value);
                }
                return BadRequest(validationErrors);
            }
        }

        [Tags("PayAll.Recipients")]
        [HttpDelete(PayAllUrl.DeleteRecipient)]
        public object DeleteRecipient(Guid id)
        {
            var result = _payAllClient.Recipients().DeleteRecipient(id);
            return Ok(result);
        }

        [Tags("PayAll.Discovery")]
        [HttpGet(PayAllUrl.GetRequiredPaymentFieldsUrl)]
        public object GetRequiredPaymentFields()
        {
            try
            {
                return _payAllClient.Discovery().GetRequiredPaymentFields();
            }
            catch (System.Exception e)
            {
                if (e.Message == "Unauthorized")
                {
                    return Unauthorized();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [Tags("PayAll.Compliance")]
        [HttpPost(PayAllUrl.UploadNewComplianceDocumentUrl)]
        public object UploadNewComplianceDocument(IFormFile file)
        {
            try
            {
                return _payAllClient.UploadNewComplianceDocument(file);
            }
            catch (System.Exception e)
            {
                if (e.Message == "Unauthorized")
                {
                    return Unauthorized();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [Tags("PayAll.Payers")]
        [HttpGet(PayAllUrl.GetPayers)]
        public object GetPayers()
        {
            var result = _payAllClient.Payers().GetPayers();
            return Ok(result);
        }

        [Tags("PayAll.Payers")]
        [HttpPost(PayAllUrl.CreatePayers)]
        public object CreatePayers(PayerRequest request)
        {
            try
            {
                var result = _payAllClient.Payers().CreatePayers(request);
                return Ok(result);
            }
            catch (ValidationsException ex)
            {
                var validationErrors = new Dictionary<string, string>();
                foreach (var error in ex.ValidationErrors)
                {
                    validationErrors[error.Key] = string.Join("; ", error.Value);
                }
                return BadRequest(validationErrors);
            }
            

        }

        [Tags("PayAll.Payers")]
        [HttpGet(PayAllUrl.GetPayer)]
        public object GetPayer(Guid id)
        {
            var result = _payAllClient.Payers().GetPayerByID(id);
            return Ok(result);
        }

        [Tags("PayAll.Payers")]
        [HttpGet(PayAllUrl.GetPayerAccounts)]
        public object GetPayerAccounts(Guid id)
        {
            var result = _payAllClient.Payers().GetPayerAccounts(id);
            return Ok(result);
        }

        private CreatePaymentRequest CreatePaymentRequest()
        {

            var paymentData = new CreatePaymentRequest
            {
                client_payment_id = "CP12345",
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
                payment_instrument = new PaymentInstrumentRequest
                {
                    category = "Credit Card",
                    currency = "USD",
                    mobile_number = "+123456789"
                },
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

        private PaymentUpdateRequest UpdatePaymentRequest()
        {
            return new PaymentUpdateRequest
            {
                supporting_documents = new List<SupportingDocument>{
                                        new SupportingDocument { document_id = "3fa85f64-5717-4562-b3fc-2c963f66afa6" }
            },
                exchange_rate_id = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
        }

        private PaymentInstrumentsRequest CreatePaymentInstrumentsRequest()
        {
            var request = new PaymentInstrumentsRequest();

            request.category = "MobileWallet";
            request.currency = "USD";
            request.recipient_id = "123654";

            return request;
        }
    }
}
