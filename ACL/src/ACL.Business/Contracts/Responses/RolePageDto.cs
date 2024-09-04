
namespace ACL.Business.Contracts.Responses;

public record RolePageDto(
    uint role_id,
    int[] page_ids
    );
