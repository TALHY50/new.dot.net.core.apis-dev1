using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;

namespace Admin.Web.Infrastructure.Persistence;

public static class AdminPersistenceDependencyInjection
{
    public static IServiceCollection AddAdminPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}