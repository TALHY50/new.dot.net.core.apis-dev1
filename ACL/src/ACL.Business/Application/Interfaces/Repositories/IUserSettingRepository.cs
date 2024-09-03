using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using SharedKernel.Main.Application.Interfaces.Repositories;

namespace ACL.Business.Application.Interfaces.Repositories;

public interface IUserSettingRepository  : IRepositoryBase<UserSetting>, IExtendedRepositoryBase<UserSetting>
{
    
}