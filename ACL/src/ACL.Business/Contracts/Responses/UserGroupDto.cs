namespace ACL.Business.Contracts.Responses
{
    public record UserGroupDto(
        uint Id,
        string GroupName,
        sbyte Category,
        sbyte Status,
        uint CompanyId
        );
}
