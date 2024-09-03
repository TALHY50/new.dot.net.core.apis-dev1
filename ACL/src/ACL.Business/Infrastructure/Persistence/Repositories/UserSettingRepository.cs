using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    public class UserSettingRepository (ApplicationDbContext dbContext) : EfRepository<UserSetting>(dbContext), IUserSettingRepository
    {
    }
}
