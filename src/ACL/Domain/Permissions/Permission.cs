namespace ACL.Domain.Permissions;

public class Permission
{
    public uint Version { get; private set; }
    public HashSet<string>? PermittedRoutes { get; private set; }

    public Permission(HashSet<string>? permittedRoutes)
    {
        this.PermittedRoutes = permittedRoutes;
    }

}