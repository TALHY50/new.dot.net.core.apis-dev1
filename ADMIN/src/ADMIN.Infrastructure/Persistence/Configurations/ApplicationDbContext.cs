using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using SharedKernel.Interfaces;
using System;
using ADMIN.Core.Entities.Provider;

namespace ADMIN.Infrastructure.Persistence.Configurations
{
    public partial class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options), IApplicationDbContext
    {
        public virtual DbSet<AdminProvider> Admin_Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                DotNetEnv.Env.NoClobber().TraversePath().Load();
                string server = DotNetEnv.Env.GetString("DB_HOST");
                string database = DotNetEnv.Env.GetString("DB_DATABASE");
                string userName = DotNetEnv.Env.GetString("DB_USERNAME");
                string password = DotNetEnv.Env.GetString("DB_PASSWORD");
                string port = DotNetEnv.Env.GetString("DB_PORT");

                var connectionString = $"server={server};port={port};database={database};user={userName};password={password};charset=utf8mb4;";

                optionsBuilder.UseMySQL(connectionString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminProvider>().HasKey(e => e.Id);
        }
    }
}