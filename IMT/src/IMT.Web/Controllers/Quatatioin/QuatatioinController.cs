using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using IMT.Thunes;
using IMT.Thunes.Exception;
using IMT.Thunes.Request.Transaction.Quoatation;
using IMT.Thunes.Response.Common;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers.Quatatioin
{

    [ApiController]
    [Tags("Quatatioin")]
    [Route("[controller]")]
    public class QuatatioinController : BaseController
    {

        [Tags("Thunes.Quatation")]
        [HttpPost(ThunesUrl.CreateQuatationUrl)]
        public object CreateQuatatioin(CreateQuatationRequest request)
        {
            try
            {
                return this._thunesClient.QuotationAdapter().CreateQuatatioin(request);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

    }
}