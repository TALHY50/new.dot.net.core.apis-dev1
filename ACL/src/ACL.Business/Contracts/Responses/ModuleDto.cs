namespace ACL.Business.Contracts.Responses;

public record ModuleDto(

    uint id, string name, string icon, int sequence, string display_name
    );