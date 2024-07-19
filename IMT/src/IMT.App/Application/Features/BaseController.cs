using Microsoft.AspNetCore.Mvc;
using Thunes;

namespace App.Application.Features
{
    public class BaseController : ControllerBase
    {
        public readonly ThunesClient _thunesClient;
        public BaseController()
        {
           // _thunesClient = new(Env.GetString("THUNES_API_KEY"), Env.GetString("THUNES_API_SECRET"), Env.GetString("THUNES_BASE_URL"));
            _thunesClient = new("f1c4a4d9-2899-4f09-b9f5-c35f09df5ffd", "bed820bd-264b-4d0f-8148-9f56e0a8b55c", "https://api-mt.pre.thunes.com");
        }
    }
}