using ACL.Bussiness.Contracts.Requests;
using ACL.Bussiness.Domain.Entities;

namespace ACL.Bussiness.Application.Interfaces.Repositories
{
    /// <inheritdoc/>
    public interface IPageRouteRepository
    {
        /// <inheritdoc/>
        PageRoute PreparePageRouteInputData(AclPageRouteRequest request, PageRoute? aclPageRoute = null);
        /// <inheritdoc/>
        List<PageRoute>? All();
        /// <inheritdoc/>
        PageRoute? Find(ulong id);
        /// <inheritdoc/>
        PageRoute? Add(PageRoute pageRoute);
        /// <inheritdoc/>
        PageRoute? Update(PageRoute pageRoute);
        /// <inheritdoc/>
        PageRoute? Delete(PageRoute pageRoute);
        /// <inheritdoc/>
        PageRoute? Delete(ulong id);
        /// <inheritdoc/>
        PageRoute[]? DeleteAllByPageId(ulong pageid);
    }
}
