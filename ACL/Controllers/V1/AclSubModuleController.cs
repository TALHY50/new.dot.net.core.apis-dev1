
using ACL.Interfaces.Repositories;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Route;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [ApiController]
    [Route("api/v1")]
    public class AclSubModuleController : ControllerBase
    {
        private readonly IAclSubModuleRepository _repository;
        public AclSubModuleController(IAclSubModuleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(AclRoutesUrl.AclSubModule.List , Name = AclRoutesName.SubmoduleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return _repository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclSubModule.Add , Name = AclRoutesName.SubmoduleRouteNames.Add)]
        public async Task<AclResponse> Create(AclSubModuleRequest objSubModule)
        {
           return _repository.Add(objSubModule);
        }

        [HttpGet(AclRoutesUrl.AclSubModule.View , Name = AclRoutesName.SubmoduleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return _repository.findById(id);

        }


        [HttpPut(AclRoutesUrl.AclSubModule.Edit , Name = AclRoutesName.SubmoduleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return _repository.Edit(id, objSubModule);

        }


        [HttpDelete(AclRoutesUrl.AclSubModule.Destroy , Name = AclRoutesName.SubmoduleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _repository.deleteById(id);
        }




    }
}
