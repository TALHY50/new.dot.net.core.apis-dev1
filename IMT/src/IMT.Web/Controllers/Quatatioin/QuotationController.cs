using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using IMT.Thunes;
using IMT.Thunes.Exception;
using IMT.Thunes.Request.Transaction.Quotation;
using IMT.Thunes.Response.Common;
using IMT.Thunes.Route;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers.Quotation
{

    [ApiController]
    [Tags("Quotation")]
    [Route("[controller]")]
    public class QuotationController : BaseController
    {

        [Tags("Thunes.Quotation")]
        [HttpPost(ThunesUrl.CreateQuotationUrl)]
        public object CreateQuotation(CreateQuotationRequest request)
        {
            try
            {
                return this._thunesClient.QuotationAdapter().CreateQuotation(request);
            }
            catch (ThunesException e)
            {
                return StatusCode(e.ErrorCode, e.Errors);
            }
        }

    }
}