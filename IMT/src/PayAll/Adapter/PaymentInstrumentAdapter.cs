using System.ComponentModel.DataAnnotations;
using PayAll.Common;
using PayAll.Model;
using PayAll.Net;
using PayAll.Request.Common;
using PayAll.Request.PaymentInstructionRequest;
using PayAll.Request.PaymentInstructionUpdateRequest;
using PayAll.Response.PaymentInstruments;
using PayAll.Route;

namespace PayAll.Adapter
{
    public class PaymentInstrumentAdapter : BaseAdapter
    {
        public PaymentInstrumentAdapter(RequestOptions requestOptions) : base(requestOptions)
        {
        }

        // Get list of payment instruments
        public List<PaymentInstrumentsResponse> GetPaymentInstrumentsList(SearchPaymentInstrumentsRequest request)
        {
            var queryParam = RequestQueryParamsBuilder.BuildQueryParam(request);
            var path = PayAllUrl.PaymentInstrumentsList + queryParam;
            return RestClient.Get<List<PaymentInstrumentsResponse>>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }

        // Create a payment instrument
        public PaymentInstrumentsCreateResponse CreatePaymentInstruments(PaymentInstrumentsRequest request)
        {
            var path = PayAllUrl.CreatePaymentInstruments;
            var paymentInstrumentsRequest = PaymentInstruments(request);
            return RestClient.Post<PaymentInstrumentsCreateResponse>(RequestOptions.BaseUrl + path, CreateHeaders(paymentInstrumentsRequest, path, RequestOptions), paymentInstrumentsRequest);
        }


        // Get payment instrument by its ID
        public PaymentInstrumentsResponse GetPaymentInstrumentsByID(Guid Id)
        {
            var path = PayAllUrl.GetPaymentInstrumentsByID.Replace("{id}", Id.ToString());
            return RestClient.Get<PaymentInstrumentsResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }

        // Update a payment instrument
        public PaymentInstrumentsResponse UpdatePaymentInstrumentsById(Guid Id, PaymentInstrumentsUpdateRequest request)
        {
            var path = PayAllUrl.UpdatePaymentInstrumentsByID.Replace("{id}", Id.ToString());
            var paymentInstrumentsRequest = PaymentInstrumentsUpdate(request);
            return RestClient.Patch<PaymentInstrumentsResponse>(RequestOptions.BaseUrl + path, CreateHeaders(paymentInstrumentsRequest, path, RequestOptions), paymentInstrumentsRequest);
        }

        // Delete a payment instrument
        public string DeletePaymentInstrumentsByID(Guid Id)
        {
            var path = PayAllUrl.DeletePaymentInstrumentsByID.Replace("{id}", Id.ToString());
            return RestClient.Delete<string>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }



        private object PaymentInstruments(PaymentInstrumentsRequest request)
        {
            if (request.category == PaymentInstrumentCategory.MobileWallet.ToString())
            {
                var model = new MobileWalletRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    mobile_number = request.mobile_number,
                    recipient_id = request.recipient_id

                };
                Validation.ValidateModel(model);
                return model;
            }
            if (request.category == PaymentInstrumentCategory.BankAccount.ToString())
            {
                var model = new BankAccountRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    recipient_id = request.recipient_id,
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
                var model = new CashPickupRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    recipient_id = request.recipient_id,
                    first_name = request.first_name,
                    last_name = request.last_name
                };
                Validation.ValidateModel(model);
                return model;
            }
            if (request.category == PaymentInstrumentCategory.Card.ToString())
            {
                var model = new CardRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    recipient_id = request.recipient_id,
                    token = request.token
                };
                Validation.ValidateModel(model);
                return model;
            }

            throw new ValidationException("Category must be MobileWallet,BankAccount,CashPickup,Card");

        }

        private object PaymentInstrumentsUpdate(PaymentInstrumentsUpdateRequest request)
        {
            if (request.category == PaymentInstrumentCategory.MobileWallet.ToString())
            {
                var model = new MobileWalletUpdateRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    mobile_number = request.mobile_number
                   
                };
                Validation.ValidateModel(model);
                return model;
            }
            if (request.category == PaymentInstrumentCategory.BankAccount.ToString())
            {
                var model = new BankAccountUpdateRequest()
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
                var model = new CashPickupUpdateRequest()
                {
                    category = request.category,
                    currency = request.currency,
                    first_name = request.first_name,
                    last_name = request.last_name
                };
                Validation.ValidateModel(model);
                return model;
            }
            if (request.category == PaymentInstrumentCategory.Card.ToString())
            {
                var model = new CardUpdateRequest()
                {
                    category = request.category,
                    currency = request.currency
                };
                Validation.ValidateModel(model);
                return model;
            }

            throw new ValidationException("Category must be MobileWallet,BankAccount,CashPickup,Card");

        }

    }
}