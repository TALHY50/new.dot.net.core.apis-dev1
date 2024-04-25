﻿
using ACL.Database.Models;
using ACL.Requests;
using ACL.Response.V1;

namespace ACL.Interfaces.Repositories.V1

{
    public interface IAclCountryRepository : IGenericRepository<AclCountry>
    {
        Task<AclResponse> GetAll();
        Task<AclResponse> Add(AclCountryRequest request);
        Task<AclResponse> Edit(ulong id, AclCountryRequest request);
        Task<AclResponse> FindById(ulong id);
        Task<AclResponse> DeleteById(ulong id);
    }
}
