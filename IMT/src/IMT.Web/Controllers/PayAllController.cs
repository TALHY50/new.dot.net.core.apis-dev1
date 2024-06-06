﻿
using IMT.PayAll;
using IMT.PayAll.Request;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.PaymentRequest;
using IMT.PayAll.Response;
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
        public PayAllController()
        {
            _payAllClient = new PayAllClient("client-id", "client-secret", "https://api.sandbox.payall.com");
        }
        [Tags("PayAll.Payment")]
        [HttpPost(PayAllUrl.SinglePayment)]
        public object SinglePayment(CreatePaymentRequest requests)
        {
            var request = CreatePaymentRequest();
            return _payAllClient.Payment().SinglePayment(request);
        }

        [Tags("PayAll.Payment")]
        [HttpGet(PayAllUrl.GetPaymentById)]
        public object GetPaymentById(string id)
        {
            var result = _payAllClient.Payment().GetPaymentById(id);
            return Ok(result);
        }

        [Tags("PayAll.Payment")]
        [HttpPatch(PayAllUrl.UpdatePaymentById)]
        public object UpdatePaymentById(string id)
        {
            var request = UpdatePaymentRequest();
            var result = _payAllClient.Payment().UpdatePaymentDetailsById(id, request);
            return Ok(result);
        }

        [Tags("PayAll.Payment Instruments")]
        [HttpGet(PayAllUrl.PaymentInstrumentsList)]
        public object PaymentInstrumentsList(string? recipient_id)
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
            var result = _payAllClient.PaymentInstruments().CreatePaymentInstruments(request);
            return Ok(result);
        }

        [Tags("PayAll.Payment Instruments")]
        [HttpGet(PayAllUrl.GetPaymentInstrumentsByID)]
        public object GetPaymentInstrumentsById(string id)
        {
            var result = _payAllClient.PaymentInstruments().GetPaymentInstrumentsByID(id);
            return Ok(result);
        }

        [Tags("PayAll.Payment Instruments")]
        [HttpPatch(PayAllUrl.UpdatePaymentInstrumentsByID)]
        public object UpdatePaymentInstrumentsByID(string id, PaymentInstrumentsRequest requests)
        {
            var request = CreatePaymentInstrumentsRequest();
            var result = _payAllClient.PaymentInstruments().UpdatePaymentInstrumentsById(id, request);
            return Ok(result);
        }


        [Tags("PayAll.Payment Instruments")]
        [HttpDelete(PayAllUrl.DeletePaymentInstrumentsByID)]
        public object DeletePaymentInstrumentsById(string id)
        {
            var result = _payAllClient.PaymentInstruments().DeletePaymentInstrumentsByID(id);
            return Ok(result);
        }

        [Tags("PayAll.Exchange")]
        [HttpGet(PayAllUrl.GetExchangeRateByID)]
        public object GetExchangeRateById(string id)
        {
            var result = _payAllClient.Exchanges().GetExchangeRateByID(id);
            return Ok(result);
        }

        private CreatePaymentRequest CreatePaymentRequest()
        {

            var paymentData = new CreatePaymentRequest
            {
                client_payment_id = "CP12345",
                recipient = new Recipient
                {
                    type = "Business",
                    email = "john.doe@example.com",
                    first_name = "John",
                    last_name = "Doe",
                    middle_name = "A",
                    mobile_number = "+123456789",
                    dob = new DateOnly(),
                    registration_address = new List<RegistrationAddress>
                {
                    new RegistrationAddress
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
                    identity_document = new IdentityDocument
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
                payment_instrument = new PaymentInstrument
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
                kyt = new Kyt
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