using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SharedKernel.Main.Infrastructure.Persistence.Configurations
{
     public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json")  
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            DotNetEnv.Env.NoClobber().TraversePath().Load();
                string server = DotNetEnv.Env.GetString("DB_HOST");
                string database = DotNetEnv.Env.GetString("DB_DATABASE");
                string userName = DotNetEnv.Env.GetString("DB_USERNAME");
                string password = DotNetEnv.Env.GetString("DB_PASSWORD");
                string port = DotNetEnv.Env.GetString("DB_PORT");

                var connectionString = $"server={server};port={port};database={database};user={userName};password={password};charset=utf8mb4;";

                builder.UseMySQL(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
