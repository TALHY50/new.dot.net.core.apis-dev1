using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;

namespace ACL.Business.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IPageRouteRepository
    {
        /// <inheritdoc/>
        PageRoute PreparePageRouteInputData(AclPageRouteRequest request, PageRoute? aclPageRoute = null);
        /// <inheritdoc/>
        List<PageRoute>? All();
        /// <inheritdoc/>
        PageRoute? Find(uint id);
        /// <inheritdoc/>
        PageRoute? Add(PageRoute pageRoute);
        /// <inheritdoc/>
        PageRoute? Update(PageRoute pageRoute);
        /// <inheritdoc/>
        PageRoute? Delete(PageRoute pageRoute);
        /// <inheritdoc/>
        PageRoute? Delete(uint id);
        /// <inheritdoc/>
        PageRoute[]? DeleteAllByPageId(uint pageid);
    }
}
