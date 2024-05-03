
using Microsoft.EntityFrameworkCore;
using ACL.Database;
using DotNetEnv;

namespace ACL.Tests
{
    public class DatabaseConnector
    {
        public string baseUrl;
        private string connectionString;
        public ApplicationDbContext dbContext;

        public DatabaseConnector(bool isLocalDb = false)
        {
            Env.NoClobber().TraversePath().Load();

            baseUrl = Env.GetString("APP_URL");

            var server = Env.GetString("DB_HOST");
            var database = Env.GetString("DB_DATABASE");
            var userName = Env.GetString("DB_USERNAME");
            var password = Env.GetString("DB_PASSWORD");

            this.connectionString = $"server={server};database={database};User ID={userName};Password={password};" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySQL(connectionString).Options;

            if (isLocalDb)
            {
                options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "acl").Options;
            }

            dbContext = new ApplicationDbContext(options);

        }

    }
}