﻿using IMT.PayAll;
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
        CreateNewTransactionRequest CreateTransactionFromJson(string json)
        {
            return JsonConvert.DeserializeObject<CreateNewTransactionRequest>(json);
        }
    }
}
