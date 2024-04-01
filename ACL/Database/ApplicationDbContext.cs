using ACL.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ACL.Database
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
        public virtual DbSet<AclCompanyModule> AclCompanyModules { get; set; } = null!;
    }

}
