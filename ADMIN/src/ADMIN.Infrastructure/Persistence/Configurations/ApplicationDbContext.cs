
using ADMIN.Core.Entities.AdminProvider;
using Microsoft.EntityFrameworkCore;

namespace ADMIN.Infrastructure.Persistence.Configurations
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public virtual DbSet<AdminProvider> AdminProviders { get; set; }


    }
}