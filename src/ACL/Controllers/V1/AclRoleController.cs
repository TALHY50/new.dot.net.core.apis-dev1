
using ACL.Interfaces;
using ACL.Requests;
using ACL.Response.V1;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
{
    [Tags("Role")]
    [ApiController]
    public class AclRoleController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        public AclRoleController(IUnitOfWork repository)
        {
            _repository = repository;
        }

        [HttpGet(Route.AclRoutesUrl.AclRole.List, Name = Route.AclRoutesName.AclRole.List)]
        public async Task<AclResponse> Index()
        {
            return await _repository.AclRoleRepository.GetAll();
        }

        [HttpPost(Route.AclRoutesUrl.AclRole.Add, Name = Route.AclRoutesName.AclRole.Add)]
        public async Task<AclResponse> Create(AclRoleRequest objRole)
        {
            return await _repository.AclRoleRepository.Add(objRole);
        }

        [HttpGet(Route.AclRoutesUrl.AclRole.View, Name = Route.AclRoutesName.AclRole.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _repository.AclRoleRepository.FindById(id);

        }

        [HttpPut(Route.AclRoutesUrl.AclRole.Edit, Name = Route.AclRoutesName.AclRole.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclRoleRequest objRole)
        {
            return await _repository.AclRoleRepository.Edit(id, objRole);

        }

        [HttpDelete(Route.AclRoutesUrl.AclRole.Destroy, Name = Route.AclRoutesName.AclRole.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _repository.AclRoleRepository.DeleteById(id);
        }

    }
}
