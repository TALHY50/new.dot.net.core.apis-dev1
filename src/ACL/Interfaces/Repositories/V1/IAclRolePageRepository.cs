﻿using ACL.Database.Models;
using ACL.Requests;
using ACL.Response.V1;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;
using ACL.Database;

namespace ACL.Interfaces.Repositories.V1
{
    public interface IAclRolePageRepository : IGenericRepository<AclRolePage>
    {
        Task<AclResponse> GetAllById(ulong Id);
        Task<AclResponse> UpdateAll(AclRoleAndPageAssocUpdateRequest req);
        Database.Models.AclRolePage[] PrepareData(AclRoleAndPageAssocUpdateRequest req);
    }
}