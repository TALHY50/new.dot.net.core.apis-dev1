
using IMT.PayAll.Net;
using IMT.PayAll.Request;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.PaymentRequest;
using IMT.PayAll.Request.Recipient;
using IMT.PayAll.Response;
using IMT.PayAll.Route;


namespace IMT.PayAll.Adapter
{
    public class PaymentAdapter : BaseAdapter
    {
        private enum recipientType { Person, Business };
        private enum paymentInstrumentCategory { MobileWallet, BankAccount, CashPickup, Card };
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
            singlePayment.payment_instrument = PaymentInstruments(request.payment_instrument);
            singlePayment.recipient = GetRecipient(request.recipient);
            return singlePayment;
        }

        private object PaymentInstruments(PaymentInstrumentRequest request)
        {
            if (request.category == paymentInstrumentCategory.MobileWallet.ToString())
            {
                return new MobileWalletRequest { category = request.category, currency = request.currency, mobile_number = request.mobile_number };
            }
            if (request.category == paymentInstrumentCategory.BankAccount.ToString())
            {
                return new BankAccountRequest
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

            }
            if (request.category == paymentInstrumentCategory.CashPickup.ToString())
            {
                return new CashPickupRequest
                {
                    category = request.category,
                    currency = request.currency,
                    first_name = request.first_name,
                    last_name = request.last_name
                };

            }
            if (request.category == paymentInstrumentCategory.Card.ToString()) {

              return  new CardRequest
                {
                    category = request.category,
                    currency = request.currency
                };
            }

            return null;

        }

        private object GetRecipient(RecipientRequest request)
        {
            if (request.type == recipientType.Business.ToString())
            {
               return new BusinessRecipientRequest
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

            }
            if (request.type == recipientType.Person.ToString())
            {
                return new PersonRecipientRequest
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

            }
           
            return null;

        }


    }
}