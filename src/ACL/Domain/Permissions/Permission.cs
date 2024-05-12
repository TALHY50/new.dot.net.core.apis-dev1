namespace ACL.Domain.Permissions;

public class Permission
{
    public HashSet<string> PermittedRoutes;

    public Permission(HashSet<string> permittedRoutes)
    {
        this.PermittedRoutes = permittedRoutes;
    }

}