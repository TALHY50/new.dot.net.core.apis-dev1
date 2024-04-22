
using Microsoft.EntityFrameworkCore;
using ACL.Database;

namespace ACL.Tests
{
    public class DatabaseConnector
    {
        public string baseUrl = "https://localhost:7125/v1/api/";
        private string connectionString;
        public ApplicationDbContext dbContext;

        public DatabaseConnector(bool isLocalDb = false)
        {
            var server = "127.0.0.1";var database = "acl_db";var userName = "root";var password = "";
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