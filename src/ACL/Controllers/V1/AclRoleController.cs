
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
        private readonly ICustomUnitOfWork _unitOfWork;
        public AclRoleController(ICustomUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Route.AclRoutesUrl.AclRoleRouteUrl.List, Name = Route.AclRoutesName.AclRoleRouteNames.List)]
        public async Task<AclResponse> Index()
        {
            return await _unitOfWork.AclRoleRepository.GetAll();
        }

        [HttpPost(Route.AclRoutesUrl.AclRoleRouteUrl.Add, Name = Route.AclRoutesName.AclRoleRouteNames.Add)]
        public async Task<AclResponse> Create(AclRoleRequest objRole)
        {
            return await _unitOfWork.AclRoleRepository.Add(objRole);
        }

        [HttpGet(Route.AclRoutesUrl.AclRoleRouteUrl.View, Name = Route.AclRoutesName.AclRoleRouteNames.View)]
        public async Task<AclResponse> View(ulong id)
        {
            return await _unitOfWork.AclRoleRepository.FindById(id);

        }

        [HttpPut(Route.AclRoutesUrl.AclRoleRouteUrl.Edit, Name = Route.AclRoutesName.AclRoleRouteNames.Edit)]
        public async Task<AclResponse> Edit(ulong id, AclRoleRequest objRole)
        {
            return await _unitOfWork.AclRoleRepository.Edit(id, objRole);

        }

        [HttpDelete(Route.AclRoutesUrl.AclRoleRouteUrl.Destroy, Name = Route.AclRoutesName.AclRoleRouteNames.Destroy)]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return await _unitOfWork.AclRoleRepository.DeleteById(id);
        }

    }
}
