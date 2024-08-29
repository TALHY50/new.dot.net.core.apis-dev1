using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Infrastructure.Services;

namespace SharedBusiness.Main.IMT.Infrastructure.Persistence.Repositories;

public class HolidaySettingRepository(ApplicationDbContext dbContext) : GenericRepository<HolidaySetting, ApplicationDbContext>(dbContext), IHolidaySettingRepository
{
}
