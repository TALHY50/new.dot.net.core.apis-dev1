﻿using IMT.PayAll;
using IMT.Thunes;
using IMT.Thunes.Request;
using IMT.Thunes.Response;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThunesController : ControllerBase
    {

        private readonly ThunesClient _thunesClient =
            new ThunesClient("api-key", "secret-key", "https://api.limonetikqualif.com");


        [HttpPost(Name = "CreateQuotation")]
        public Object Post()
        {
            CreateQuatationRequest? request = new CreateQuatationRequest();
            var response = _thunesClient.CreateQuotation(request);
           return response;
        }
    }
}
