using IMT.PayAll;
using IMT.Thunes;
using IMT.Thunes.Request;
using IMT.Thunes.Request.CreditParties;
using IMT.Thunes.Request.CreditParties.Common;
using IMT.Thunes.Response;
using IMT.Thunes.Response.CreditParties;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {

        private readonly ThunesClient _thunesClient =
            new ThunesClient("api-key", "secret-key", "http://localhost:3001");


        [HttpGet("CreateQuatatioin")]
        public CreateQuatationResponse Get()
        {
            CreateQuatationRequest? request = new CreateQuatationRequest();
            return _thunesClient.QuotationAdapter().CreateQuatatioin(request);
        }

        [HttpGet("GetQuotationById")]
        public CreateQuatationResponse GetById()
        {

            int id = 1;
            return _thunesClient.QuotationAdapter().GetQuotationById(id);
        }

        [HttpGet("GetRetrieveQuotationByExternalId")]
        public CreateQuatationResponse GetByExternalId()
        {
            ulong id = 1481184321405;
            return _thunesClient.QuotationAdapter().GetRetrieveQuotationByExternalId(id);
        }


        [HttpGet("CreditPartyInformation")]
        public InformationResponse GetInformationAdapter()
        {
            InformationRequest request = new InformationRequest
            {
                credit_party_identifier = new CreditPartyIdentifier
                {
                    msisdn = "263775892364",
                }
            };
            // request = new InformationRequest();
            ulong id = 1;
            string transaction_type = "C2C";
            return _thunesClient.GetInformationAdapter().CreditPartyInformation(request, id, transaction_type);
        }
    }
}
