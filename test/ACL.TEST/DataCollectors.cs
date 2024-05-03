
using ACL.Database;
using ACL.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace ACL.Tests
{
    public static class DataCollectors
    {
        public static string baseUrl;
        private static string connectionString;
        public static ApplicationDbContext dbContext;
        public static CustomUnitOfWork unitOfWork;
        public static string Authorization;

        public static void SetDatabase(bool isLocalDb = false)
        {
            Env.NoClobber().TraversePath().Load();

            baseUrl = Env.GetString("APP_URL");

            var server = Env.GetString("DB_HOST");
            var database = Env.GetString("DB_DATABASE");
            var userName = Env.GetString("DB_USERNAME");
            var password = Env.GetString("DB_PASSWORD");

            connectionString = $"server={server};database={database};User ID={userName};Password={password};" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySQL(connectionString).Options;

            if (isLocalDb)
            {
                options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "acl").Options;
            }

            dbContext = new ApplicationDbContext(options);
            unitOfWork = new CustomUnitOfWork(dbContext);
            unitOfWork.ApplicationDbContext = dbContext;

        }

        public static string getRandomEmail()
        {
            return unitOfWork.ApplicationDbContext.AclUsers.FirstOrDefault().Email;
        }

        public static ulong GetMaxId<TEntity>(Func<TEntity, ulong> idSelector) where TEntity : class
        {
            ulong id = 0;
            var entities = unitOfWork.ApplicationDbContext.Set<TEntity>();
            if (entities.Any())
            {
                id = entities.Max(idSelector);
            }
            return id;
        }

        public static string GetAuthorization()
        {
            //return Authorization = "Bearer "+"";
            return Authorization = "jfkjdkfjklsdjf";
        }


    }
}