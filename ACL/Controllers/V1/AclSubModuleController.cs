using ACL.Interfaces;
using ACL.Interfaces.Repositories.V1;
using ACL.Requests;
using ACL.Response.V1;
using ACL.Route;
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

        [HttpGet(AclRoutesUrl.AclSubModule.List, Name = AclRoutesName.SubmoduleRouteNames.List)]
        public AclResponse Index()
        {
            return _repository.AclSubModuleRepository.GetAll();
        }

        [HttpPost(AclRoutesUrl.AclSubModule.Add, Name = AclRoutesName.SubmoduleRouteNames.Add)]
        public AclResponse Create(AclSubModuleRequest objSubModule)
        {
            return _repository.AclSubModuleRepository.Add(objSubModule);
        }

        [HttpGet(AclRoutesUrl.AclSubModule.View, Name = AclRoutesName.SubmoduleRouteNames.View)]
        public AclResponse View(ulong id)
        {
            return _repository.AclSubModuleRepository.findById(id);

        }


        [HttpPut(AclRoutesUrl.AclSubModule.Edit, Name = AclRoutesName.SubmoduleRouteNames.Edit)]
        public AclResponse Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return _repository.AclSubModuleRepository.Edit(id, objSubModule);

        }


        [HttpDelete(AclRoutesUrl.AclSubModule.Destroy, Name = AclRoutesName.SubmoduleRouteNames.Destroy)]
        public AclResponse Destroy(ulong id)
        {
            return _repository.AclSubModuleRepository.deleteById(id);
        }




    }
}
