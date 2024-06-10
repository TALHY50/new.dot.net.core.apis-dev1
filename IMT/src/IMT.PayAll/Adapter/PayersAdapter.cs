
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
        public PayersResponse GetPayerAccounts(Guid payerId)
        {
            var path = PayAllUrl.GetPayerAccounts.Replace("{id}", payerId.ToString());
            return RestClient.Get<PayersResponse>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }

        private object GeneratePayerRequest(PayerRequest request)
        {
            if (request.type == payerType.Business.ToString())
            {
              var model =  new BusinessPayerRequest
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
            if (request.type == payerType.Person.ToString())
            {
                var model = new PersonPayerRequest
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
