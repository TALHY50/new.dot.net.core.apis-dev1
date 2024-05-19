namespace ACL.Core.Entities.Auth;

public class Permission
{
    public uint Version { get; private set; }
    public HashSet<string>? RouteNames { get; private set; }

    public Permission(HashSet<string>? routeNames)
    {
        this.RouteNames = routeNames;
    }

}