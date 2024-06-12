
using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Common;
using IMT.PayAll.Net;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.Payer;
using IMT.PayAll.Response.Payer;
using IMT.PayAll.Route;

namespace IMT.PayAll.Adapter
{
    public class PayersAdapter : BaseAdapter
    {
        private enum payerType { Person, Business };
        public PayersAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        // Get list of payers
        public IEnumerable<PayersResponse> GetPayers()
        {
            var path = PayAllUrl.GetPayers;

            return RestClient.Get<IEnumerable<PayersResponse>>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));

        }

        // Create a payer
        public PayersResponse CreatePayers(PayerRequest request)
        {
            var path = PayAllUrl.CreatePayers;
            var payerRequest = GeneratePayerRequest(request);
            return RestClient.Post<PayersResponse>(RequestOptions.BaseUrl + path, CreateHeaders(payerRequest, path, RequestOptions), payerRequest);

        }


        // Get payer by its ID
        public PayersResponse GetPayerByID(Guid payerId)
        {
            var path = PayAllUrl.GetPayer.Replace("{id}", payerId.ToString());
            return RestClient.Get<PayersResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }

        // Get list of payer's accounts
        public List<AccountResponse> GetPayerAccounts(Guid payerId)
        {
            var path = PayAllUrl.GetPayerAccounts.Replace("{id}", payerId.ToString());
            return RestClient.Get<List<AccountResponse>>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }

        private object GeneratePayerRequest(PayerRequest request)
        {
            if (request.type == payerType.Business.ToString())
            {
                var model = new BusinessPayerRequest
                {
                    type = request.type,
                    email = request.email,
                    country = request.country,
                    legal_name = request.legal_name,
                    phone_number = request.phone_number,
                    registration_address = request.registration_address,
                    registration_number = request.registration_number,
                    trade_name = request.trade_name,
                    registration_date = request.registration_date
                };
                Validation.ValidateModel(model);
                return model;

            }
            if (request.type == payerType.Person.ToString())
            {
                var model = new PersonPayerRequest
                {
                    type = request.type,
                    email = request.email,
                    first_name = request.first_name,
                    date_of_birth = request.date_of_birth,
                    last_name = request.last_name,
                    middle_name = request.middle_name,
                    phone_number = request.phone_number,
                    registration_address = request.registration_address,
                    government_id = request.government_id,
                    nationality = request.nationality,
                    occupation = request.occupation,
                    place_of_birth = request.place_of_birth,
                    relationship_with_beneficiary = request.relationship_with_beneficiary,
                    source_of_income = request.source_of_income
                };
                Validation.ValidateModel(model);
                return model;

            }

            throw new ValidationException("Type must be Person or Business");

        }


    }
}
