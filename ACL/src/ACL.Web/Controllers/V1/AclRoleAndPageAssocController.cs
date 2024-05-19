using ACL.Application.Ports.Repositories;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Web.Controllers.V1
{
     /// <inheritdoc/>
    [Authorize]
    [Tags("Role & Page Association")]
    [ApiController]
    public class AclRoleAndPageAssocController : ControllerBase
    {
        private readonly IAclRolePageRepository _repository;
         /// <inheritdoc/>
        public AclRoleAndPageAssocController(IAclRolePageRepository repository)
        {
            this._repository = repository;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRolePageRouteUrl.List, Name = AclRoutesName.AclRolePageRouteNames.List)]
        public async Task<AclResponse> Index(ulong id)
        {
            return await this._repository.GetAllById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRolePageRouteUrl.Edit, Name = AclRoutesName.AclRolePageRouteNames.Edit)]
        public async Task<AclResponse> Update(AclRoleAndPageAssocUpdateRequest req)
        {
            return await this._repository.UpdateAll(req);
        }
    }
}
