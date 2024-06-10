
using System.ComponentModel.DataAnnotations;
using IMT.PayAll.Common;
using IMT.PayAll.Net;
using IMT.PayAll.Request.Common;
using IMT.PayAll.Request.Recipient;
using IMT.PayAll.Response;
using IMT.PayAll.Route;

namespace IMT.PayAll.Adapter
{
    public class RecipientsAdapter : BaseAdapter
    {
        private enum recipientType { Person, Business };
        public RecipientsAdapter(RequestOptions requestOptions) : base(requestOptions)
        {

        }

        // Get list of recipients
        public IEnumerable<RecipientsResponse> GetRecipients()
        {
            var path = PayAllUrl.GetRecipientList;

            return RestClient.Get<IEnumerable<RecipientsResponse>>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));

        }

        // Create a recipient
        public CreateRecipientResponse CreateRecipient(RecipientRequest request)
        {
            var path = PayAllUrl.GetRecipientList;
            var recipientRequest = GenerateRecipientRequest(request);
            return RestClient.Post<CreateRecipientResponse>(RequestOptions.BaseUrl + path, CreateHeaders(recipientRequest, path, RequestOptions), recipientRequest);

        }

        // Update a recipient
        public CreateRecipientResponse UpdateRecipient(Guid recipientId ,RecipientRequest request)
        {
            var path = PayAllUrl.UpdateRecipient.Replace("{id}", recipientId.ToString());
            var recipientRequest = GenerateRecipientRequest(request);
            return RestClient.Patch<CreateRecipientResponse>(RequestOptions.BaseUrl + path, CreateHeaders(recipientRequest, path, RequestOptions), recipientRequest);

        }

        //Delete a recipient
        public string DeleteRecipient(Guid recipientId)
        {
            var path = PayAllUrl.DeleteRecipient.Replace("{id}", recipientId.ToString());
            return RestClient.Delete<string>(RequestOptions.BaseUrl + path, CreateHeaders(path, RequestOptions));
        }

        private object GenerateRecipientRequest(RecipientRequest request)
        {
            if (request.type == recipientType.Business.ToString())
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
            if (request.type == recipientType.Person.ToString())
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
