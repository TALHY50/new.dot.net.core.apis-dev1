namespace ACL.Domain.Permissions;

public class PermissionQueryResult
{
    public ulong UserId { get; set; }
    public uint PermissionVersion { get; set; }
    public ulong PageId { get; set; }
    public string PageName { get; set; }
    
    public string? PageRouteName { get; set; }
    public ulong UsergroupId { get; set; }
    public string DefaultUrl { get; set; }
    public sbyte UsergroupCategory { get; set; }
    public ulong ModuleId { get; set; }
    public string ControllerName { get; set; }
    public string SubmoduleName { get; set; }
    public ulong SubmoduleId { get; set; }
    public string MethodName { get; set; }
    public int MethodType { get; set; }
    public string DefaultMethod { get; set; }
}