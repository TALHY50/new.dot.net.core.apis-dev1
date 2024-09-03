namespace ACL.Business.Infrastructure.Persistence.Dtos;

public class PermissionQueryResult
{
    public uint UserId { get; set; }
    public uint PermissionVersion { get; set; }
    public uint PageId { get; set; }
    public string? PageName { get; set; }
    
    public string? PageRouteName { get; set; }
    public uint UserGroupId { get; set; }
    public string? DefaultUrl { get; set; }
    public sbyte UserGroupCategory { get; set; }
    public uint ModuleId { get; set; }
    public string? ControllerName { get; set; }
    public string? SubmoduleName { get; set; }
    public uint SubmoduleId { get; set; }
    public string? MethodName { get; set; }
    public int MethodType { get; set; }
    public string? DefaultMethod { get; set; }
    
    public uint RoleId { get; set; }
}