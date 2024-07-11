using Notification.Application.Contracts.Requests;
using Notification.Application.Domain.Module;

namespace ACL.Application.Domain.Ports.Repositories.Module
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
