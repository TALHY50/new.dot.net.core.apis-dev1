using System.ComponentModel.DataAnnotations;
using PayAll.Common;
using PayAll.Model;
using PayAll.Net;
using PayAll.Request.Common;
using PayAll.Request.Payment;
using PayAll.Request.PaymentRequest;
using PayAll.Request.Recipient;
using PayAll.Response.Payment;
using PayAll.Route;

namespace PayAll.Adapter
{
    public class PaymentAdapter : BaseAdapter
    {
        public PaymentAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        // Initiate a single payment
        public PaymentResponse SinglePayment(CreatePaymentRequest createPaymentRequest)
        {
            var path = PayAllUrl.SinglePayment;
            var request = GeneratePaymentRequest(createPaymentRequest);
            return RestClient.Post<PaymentResponse>(RequestOptions.BaseUrl + path, CreateHeaders(request, path, RequestOptions), request);

        }

        // Get payment information by its ID
        public PaymentInformationResponse GetPaymentById(Guid Id)
        {
            var path = PayAllUrl.GetPaymentById.Replace("{id}",Id.ToString());

            return RestClient.Get<PaymentInformationResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));

        }

        // Update payment details
        public UpdatePaymentResponse UpdatePaymentDetailsById(Guid Id, PaymentUpdateRequest request)
        {
            var path = PayAllUrl.UpdatePaymentById.Replace("{id}", Id.ToString());

            return RestClient.Patch<UpdatePaymentResponse>(RequestOptions.BaseUrl + path, CreateHeaders(request, path, RequestOptions), request);

        }

        private SinglePaymentRequest GeneratePaymentRequest(CreatePaymentRequest request)
        {
            SinglePaymentRequest singlePayment = new SinglePaymentRequest();
            singlePayment.client_payment_id = request.client_payment_id;
            singlePayment.recipient_id = request.recipient_id;
            singlePayment.payment_instrument_id = request.payment_instrument_id;
            singlePayment.amount = request.amount;
            singlePayment.source_account_id = request.source_account_id;
            singlePayment.exchange_rate_id = request.exchange_rate_id;
            singlePayment.carded_rate_id = request.carded_rate_id;
            singlePayment.kyt = request.kyt;
            if (request.payment_instrument != null)
            {
                singlePayment.payment_instrument = PaymentInstruments(request.payment_instrument);
            }
            if (request.recipient != null)
            {
                singlePayment.recipient = GetRecipient(request.recipient);
            }
            Validation.ValidateModel(singlePayment);
            return singlePayment;
        }

        private object PaymentInstruments(PaymentInstrumentRequest request)
        {
            if (request.category == PaymentInstrumentCategory.MobileWallet.ToString())
            {
                var model = new MobileWalletRequest { category = request.category, currency = request.currency, mobile_number = request.mobile_number };
                Validation.ValidateModel(model);
                return model;
            }
            if (request.category == PaymentInstrumentCategory.BankAccount.ToString())
            {
                var model = new BankAccountRequest
                {
                    category = request.category,
                    currency = request.currency,
                    account_id = request.account_id,
                    account_name = request.account_name,
                    account_number = request.account_number,
                    account_type = request.account_type,
                    bank_address = request.bank_address,
                    bank_branch_name = request.bank_branch_name,
                    bank_country = request.bank_country,
                    bank_domestic_code = request.bank_domestic_code,
                    bank_name = request.bank_name,
                    iban = request.iban,
                    iban_intermediary = request.iban_intermediary,
                    routing_number = request.routing_number,
                    routing_number_intermediary = request.routing_number_intermediary,
                    sub_account_number = request.sub_account_number,
                    swift_bic_code = request.swift_bic_code,
                    swift_intermediary = request.swift_intermediary,
                    urgency_flag_preference = request.urgency_flag_preference
                };
                Validation.ValidateModel(model);
                return model;

            }
            if (request.category == PaymentInstrumentCategory.CashPickup.ToString())
            {
                var model = new CashPickupRequest
                {
                    category = request.category,
                    currency = request.currency,
                    first_name = request.first_name,
                    last_name = request.last_name
                };
                Validation.ValidateModel(model);
                return model;
            }
            if (request.category == PaymentInstrumentCategory.Card.ToString()) {

              var model =  new CardRequest
                {
                    category = request.category,
                    currency = request.currency
                };
                Validation.ValidateModel(model);
                return model;
            }

            throw new ValidationException("Category must be MobileWallet,BankAccount,CashPickup,Card");

        }

        private object GetRecipient(RecipientRequest request)
        {
            if (request.type == AccountType.Business.ToString())
            {
               var model = new BusinessRecipientRequest
               {
                    type = request.type,
                    email = request.email,
                    country = request.country,
                    legal_name = request.legal_name,
                    phone_number = request.phone_number,
                    registration_address = request.registration_address,
                    registration_number = request.registration_number,
                    trade_name = request.trade_name
                };
                Validation.ValidateModel(model);
                return model;
            }
            if (request.type == AccountType.Person.ToString())
            {
                var model = new PersonRecipientRequest
                {
                    type = request.type,
                    email = request.email,
                    first_name = request.first_name,
                    dob = request.dob,
                    identity_document = request.identity_document,
                    last_name = request.last_name,
                    middle_name = request.middle_name,
                    mobile_number = request.mobile_number,
                    registration_address = request.registration_address
                };
                Validation.ValidateModel(model);
                return model;

            }

            throw new ValidationException("Type must be Person or Business");

        }


    }
}