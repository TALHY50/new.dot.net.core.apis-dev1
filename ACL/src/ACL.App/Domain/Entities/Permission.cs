namespace ACL.App.Domain.Entities;

public class Permission
{
    public uint Version { get; private set; }
    public HashSet<string>? RouteNames { get; private set; }

    public Permission(uint version, HashSet<string>? routeNames)
    {
        this.Version = version;
        this.RouteNames = routeNames;
    }

}