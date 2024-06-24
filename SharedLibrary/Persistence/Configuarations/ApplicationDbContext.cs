using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SharedLibrary.Interfaces;
using SharedLibrary.Models.Admin.Provider;
using MySql.EntityFrameworkCore.Extensions;


namespace ADMIN.Infrastructure.Persistence.Configurations
{
    public partial class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public virtual DbSet<AdminProvider> Admin_Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // if (!optionsBuilder.IsConfigured)
           // {
           Env.NoClobber().TraversePath().Load();

           string? server = Env.GetString("DB_HOST")??"127.0.0.1";
           string? database = Env.GetString("DB_DATABASE")??"acl_dot_net";
           string? userName = Env.GetString("DB_USERNAME")??"root";
           string? password = Env.GetString("DB_PASSWORD");
           string? port = Env.GetString("DB_PORT")??"3306";

           var connectionString = $"server={server};database={database};User ID={userName};Password={password};CharSet=utf8mb4;" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            optionsBuilder.UseMySQL(connectionString);
          //   }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminProvider>().HasKey(e => e.Id);
        }
    }
}