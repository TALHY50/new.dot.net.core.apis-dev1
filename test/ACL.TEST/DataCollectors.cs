
using ACL.Database;
using ACL.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace ACL.Tests
{
    public static class DataCollectors
    {
        public static string baseUrl = Env.GetString("APP_URL");
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
            return Authorization = "Bearer  "+"eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidmVyIjoiMSIsIm5iZiI6MTcxNTY4NTE0MSwiZXhwIjoxNzE1Njg1NDQxLCJpYXQiOjE3MTU2ODUxNDEsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMS8iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0LyJ9.qktXbYqYrjTY5xEEU_JGbA4GtJtmJzsk8J5G9scaOM6Nc-klcRXzEHXTlxkTDcODTOuKI9ftyI31n-r-kgmNGrDgo7XbLBSurnuyO4IjWNRc-KVv-e4gt_Chb_iOdEzsM6Oucn6VwxycMs4kgEBHgUxeWquDreBdVA0Iq1Jd0RRA4dkkSovbZw1mAs8iKivraRAnpjk7YoI4-59w33pT4Dzvy1AWlwTVDG2H1LRSENcOfMoM4ws0GXv1kIp75OexxFRxobx2pgBekgejhIsEIcMZOG8ZHkrpD6fG9RtC00q5g6GdQBL2_17Hm09H8ER25I7eN5ezNH869_wig5WnvQ";
            //return Authorization = "jfkjdkfjklsdjf";
        }


    }
}