using IMT.PayAll;
using IMT.Thunes;
using IMT.Thunes.Request;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Request.CreditParties.Common;
using IMT.Thunes.Response;
using IMT.Thunes.Response.CreditParties;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {

        private readonly ThunesClient _thunesClient = new ThunesClient("api-key", "secret-key", "https://api.limonetikqualif.com");
       // private readonly ThunesClient _thunesClient = new ThunesClient("api-key", "secret-key", "http://localhost:3001"); // mock


        [HttpPost(ThunesUrl.CreateQuatationUrl)]
        public Object QuotationPost()
        {
            CreateQuatationRequest? request = new CreateQuatationRequest();
            var response = _thunesClient.CreateQuotation(request);
           return response;
        }

        [Tags("Transaction From Quotation Id")]
        [HttpPost(ThunesUrl.CreateTransactionUrl)]
        public Object TransactionPost()
        {
            string jsonString = @"{
    'credit_party_identifier': {
        'msisdn': '+263775892100',
        'bank_account_number': '0123456789',
        'swift_bic_code': 'ABCDEFGH'
    },
    'sender': {
        'lastname': 'Doe',
        'firstname': 'John',
        'nationality_country_iso_code': 'FRA',
        'date_of_birth': '1970-01-01',
        'country_of_birth_iso_code': 'FRA',
        'gender': 'MALE',
        'address': '42 Rue des fleurs',
        'postal_code': '75000',
        'city': 'Paris',
        'country_iso_code': 'FRA',
        'msisdn': '33712345678',
        'email': 'john.doe@mail.com',
        'id_type': 'SOCIAL_SECURITY',
        'id_number': '502-42-0158',
        'id_delivery_date': '2016-01-01',
        'occupation': 'Residential Advisor'
    },
    'beneficiary': {
        'lastname': 'Doe',
        'firstname': 'Jane',
        'nationality_country_iso_code': 'FRA',
        'date_of_birth': '1971-01-01',
        'country_of_birth_iso_code': 'ZWE',
        'gender': 'MALE',
        'address': '3 Norfolk Road',
        'postal_code': '4581',
        'city': 'Harare',
        'country_iso_code': 'ZWE',
        'msisdn': '263775892364',
        'email': 'jane.doe@mail.com',
        'id_type': 'SOCIAL_SECURITY',
        'id_country_iso_code': 'ZWE',
        'id_number': '178027317681327',
        'occupation': 'Sales Executive'
    },
    'external_id': '1478078339357',
    'retail_fee': 1,
    'retail_fee_currency': 'EUR',
    'purpose_of_remittance': 'FAMILY_SUPPORT',
    'document_reference_number': '12345678',
    'callback_url': '{URL_PLACEHOLDER}',
    'reference': 'some reference'
}";
            CreateNewTransactionRequest request = CreateTransactionFromJson(jsonString);
            var response = _thunesClient.CreateTransaction(request);
            return response;
        }
        CreateNewTransactionRequest CreateTransactionFromJson(string json)
        {
            return JsonConvert.DeserializeObject<CreateNewTransactionRequest>(json);
        }
    }
}
