using ADMIN.Application.Application.Ports.Services.Interfaces.Provider;
using ADMIN.Application.Contracts.Requests;
using ADMIN.Application.Infrastructure.Route;
using Microsoft.AspNetCore.Mvc;

namespace ADMIN.Application.Application.Controllers.V1
{
    [Tags("Admin Provider")]
    [ApiController]
    public class AdminProviderController(IProviderService providerService) : Controller
    {
        [HttpGet(AdminRoutesUrl.AdminProviderUrl.List, Name = AdminRoutesNames.AdminProviderNames.List)]
        public IActionResult Index()
        {
            return Ok(providerService.GetAll());
        }

        [HttpPost(AdminRoutesUrl.AdminProviderUrl.Add, Name = AdminRoutesNames.AdminProviderNames.Add)]
        public IActionResult Add(ProviderRequest request)
        {
            return Ok(providerService.AddProvider(request));
        }        
        
        [HttpPut(AdminRoutesUrl.AdminProviderUrl.Edit, Name = AdminRoutesNames.AdminProviderNames.Edit)]
        public IActionResult Edit(ulong id, ProviderRequest request)
        {
            return Ok(providerService.UpdateProvider(id, request));
        }        
        
        [HttpGet(AdminRoutesUrl.AdminProviderUrl.Find, Name = AdminRoutesNames.AdminProviderNames.Find)]
        public IActionResult Find(ulong id)
        {
            return Ok(providerService.Find(id));
        }        
        
        [HttpDelete(AdminRoutesUrl.AdminProviderUrl.Delete, Name = AdminRoutesNames.AdminProviderNames.Delete)]
        public IActionResult Delete(ulong id)
        {
            return Ok(providerService.DeleteProvider(id));
        }
    }
}