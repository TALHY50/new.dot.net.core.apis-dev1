using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using ACL.Infrastructure.Route;
using ACL.UseCases.Interfaces.Repositories.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACL.Controllers.V1
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
            _repository = repository;
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpGet(AclRoutesUrl.AclRolePageRouteUrl.List, Name = AclRoutesName.AclRolePageRouteNames.List)]
        public async Task<AclResponse> Index(ulong id)
        {
            return await _repository.GetAllById(id);
        }
         /// <inheritdoc/>
        [Authorize(Policy = "HasPermission")]
        [HttpPut(AclRoutesUrl.AclRolePageRouteUrl.Edit, Name = AclRoutesName.AclRolePageRouteNames.Edit)]
        public async Task<AclResponse> Update(AclRoleAndPageAssocUpdateRequest req)
        {
            return await _repository.UpdateAll(req);
        }
    }
}
