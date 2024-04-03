
using ACL.Interfaces.Repositories;
using ACL.Requests;
using ACL.Response.V1;
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

        [HttpGet("submodules", Name = "acl.submodule.list")]
        public async Task<AclResponse> Index()
        {
            return _repository.GetAll();
        }

        [HttpPost("submodules/add",Name = "acl.submodule.add")]
        public async Task<AclResponse> Create(AclSubModuleRequest objSubModule)
        {
           return _repository.Add(objSubModule);
        }

        [HttpGet("submodules/view/{id}", Name = "acl.submodule.view")]
        public async Task<AclResponse> View(ulong id)
        {
            return _repository.findById(id);

        }


        [HttpPut("submodules/edit/{id}", Name = "acl.submodule.edit")]
        public async Task<AclResponse> Edit(ulong id, AclSubModuleRequest objSubModule)
        {
            return _repository.Edit(id, objSubModule);

        }


        [HttpDelete("submodules/delete/{id}", Name = "acl.submodule.destroy")]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _repository.deleteById(id);
        }




    }
}
