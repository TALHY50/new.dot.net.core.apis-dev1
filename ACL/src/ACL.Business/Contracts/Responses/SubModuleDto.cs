namespace ACL.Business.Contracts.Responses;

public record SubModuleDto(
     uint id,
     uint module_id,

    string name,

    string controller_name,

    string icon ,

    int sequence ,

    string default_method ,

    string display_name 
 );