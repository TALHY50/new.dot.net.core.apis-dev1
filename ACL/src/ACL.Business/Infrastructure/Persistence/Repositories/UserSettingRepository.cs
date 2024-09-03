using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Persistence.Repositories;

namespace ACL.Business.Infrastructure.Persistence.Repositories;

public class UserSettingRepository(ApplicationDbContext dbContext) : EfRepository<UserSetting>(dbContext), IUserSettingRepository
{
    
}