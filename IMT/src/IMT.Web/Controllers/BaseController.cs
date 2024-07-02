using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetEnv;
using IMT.Thunes;
using Microsoft.AspNetCore.Mvc;

namespace IMT.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly ThunesClient _thunesClient;
        public BaseController()
        {
            _thunesClient = new(Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_BASE_URL"));
        }
    }
}