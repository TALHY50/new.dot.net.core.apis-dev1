namespace ACL.Business.Contracts.Responses;

public record PageDto(

     uint id,

     uint module_id,

     uint submodule_id,

    string name,

    string method_name,

    /// <summary>
    /// 1=Post, 2=Get, 3=Put, 4=Delete
    /// </summary>

    int method_type,

   sbyte available_to_company,

    string display_name

 );