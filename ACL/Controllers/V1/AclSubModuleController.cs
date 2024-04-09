
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [ApiController]
    [Route(Route.AclRoutesUrl.Base)]
    public class AclSubModuleController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        public AclSubModuleController(IUnitOfWork repository)
        {
            _repository = repository;
        }

        [HttpGet(Route.AclRoutesUrl.AclSubmodule.List, Name = Route.AclRoutesName.AclSubmodule.List)]
        public AclResponse Index()
        {
            return _repository.AclSubModuleRepository.GetAll();
        }

        [HttpPost(Route.AclRoutesUrl.AclSubmodule.Add, Name = Route.AclRoutesName.AclSubmodule.Add)]
        public async Task<AclResponse> Create(AclSubModuleRequest objSubModule)
        {
            return _repository.AclSubModuleRepository.Add(objSubModule);
        }

        [HttpGet(Route.AclRoutesUrl.AclSubmodule.View, Name = Route.AclRoutesName.AclSubmodule.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return _repository.AclSubModuleRepository.findById(id);

        }


        [HttpPut(Route.AclRoutesUrl.AclSubmodule.Edit, Name = Route.AclRoutesName.AclSubmodule.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return _repository.AclSubModuleRepository.Edit(id, objSubModule);

        }


        [HttpDelete(Route.AclRoutesUrl.AclSubmodule.Destroy, Name = Route.AclRoutesName.AclSubmodule.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _repository.AclSubModuleRepository.deleteById(id);
        }




    }
}
