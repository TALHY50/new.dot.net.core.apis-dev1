﻿using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;

public class HolidaySettingRepository(ApplicationDbContext dbContext) : EfRepository<HolidaySetting>(dbContext), IHolidaySettingRepository
{
}
