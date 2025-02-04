﻿using ACL.Business.Domain.Entities;
using Ardalis.SharedKernel;
using SharedKernel.Main.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace ACL.Business.Application.Interfaces.Repositories
{
    public interface IUserSettingRepository : IExtendedRepositoryBase<UserSetting>
    {
    }
}
