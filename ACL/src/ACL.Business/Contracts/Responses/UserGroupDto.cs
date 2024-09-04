namespace ACL.Business.Contracts.Responses
{
    public record UserGroupDto(
        uint id,
        string group_name,
        sbyte category,
        string? dashboard_url,
        sbyte status,
        uint company_id
        );
}
