using ACL.App.Contracts.Requests;
using ACL.App.Domain.Module;

namespace ACL.App.Domain.Ports.Repositories.Module
{
    /// <inheritdoc/>
    public interface IAclPageRouteRepository
    {
        /// <inheritdoc/>
        AclPageRoute PreparePageRouteInputData(AclPageRouteRequest request, AclPageRoute? aclPageRoute = null);
        /// <inheritdoc/>
        List<AclPageRoute>? All();
        /// <inheritdoc/>
        AclPageRoute? Find(ulong id);
        /// <inheritdoc/>
        AclPageRoute? Add(AclPageRoute aclPageRoute);
        /// <inheritdoc/>
        AclPageRoute? Update(AclPageRoute aclPageRoute);
        /// <inheritdoc/>
        AclPageRoute? Delete(AclPageRoute aclPageRoute);
        /// <inheritdoc/>
        AclPageRoute? Delete(ulong id);
        /// <inheritdoc/>
        AclPageRoute[]? DeleteAllByPageId(ulong pageid);
    }
}
