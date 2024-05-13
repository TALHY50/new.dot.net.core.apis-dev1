namespace ACL.Domain.Permissions;

public class Permission
{
    public uint Version { get; private set; }
    public HashSet<string>? PermittedRoutes { get; private set; }

    public Permission(uint version, HashSet<string>? permittedRoutes)
    {
        this.Version = version;
        this.PermittedRoutes = permittedRoutes;
    }

}