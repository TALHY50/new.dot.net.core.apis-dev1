
using ADMIN.Core.Entities.AdminProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;


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

        public virtual DbSet<AdminProvider> Admin_Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            // {
            string server = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new InvalidOperationException("DB_HOST environment variable not found.");
            string database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? throw new InvalidOperationException("DB_DATABASE environment variable not found.");
            string userName = Environment.GetEnvironmentVariable("DB_USERNAME") ?? throw new InvalidOperationException("DB_USERNAME environment variable not found.");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");

            string connectionString = $"server={server};database={database};user={userName};password={password};CharSet=utf8mb4;";

            optionsBuilder.UseMySQL(connectionString);
            // }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminProvider>().HasKey(e => e.Id);
        }
    }
}