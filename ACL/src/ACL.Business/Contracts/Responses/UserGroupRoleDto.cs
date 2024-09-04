namespace ACL.Business.Contracts.Responses
{
    public record UserGroupRoleDto(
        uint id,
        uint usergroup_id,
        uint role_id,
        uint company_id
        );
}