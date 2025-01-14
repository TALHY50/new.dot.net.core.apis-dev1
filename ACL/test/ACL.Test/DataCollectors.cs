using System.Runtime.Caching;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Infrastructure.Persistence.Context;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace ACL.TEST
{
#pragma warning disable CS8600 // Possible null reference argument     
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS0219 // Possible null reference argument
    public static class DataCollectors
    {
        public static string baseUrl = Env.GetString("APP_URL");
        private static string connectionString;
        public static ApplicationDbContext dbContext;
        public static string Authorization;
        static MemoryCache _cache = new MemoryCache("cache");
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
            //unitOfWork = new CustomUnitOfWork(dbContext);
            //dbContext = dbContext;

        }

        public static string getRandomEmail()
        {
            return dbContext.AclUsers.FirstOrDefault().Email;
        }

        public static uint GetMaxId<TEntity>(Func<TEntity, uint> idSelector) where TEntity : class
        {
            uint id = 0;
            var entities = dbContext.Set<TEntity>();
            if (entities.Any())
            {
                id = entities.Max(idSelector);
            }
            return id;
        }

        public static string GetAuthorization()
        {
            string key = "UserToken";
            var Token = _cache.Get(key);
            if (Token == null)
            {

                Token = TestLogin();
                var cacheItem = new CacheItem(key, Token);
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(99999)
                };
                _cache.Set(cacheItem, cacheItemPolicy);

            }
            return Authorization = "Bearer  " + TestLogin();

        }
        public static string GetAuthorization(string sadmin)
        {
            string key = "UserToken";
            //var Token = _cache.Get(key);
            //if (Token == null)
            //{

            //    Token = TestLogin("sadmin");
            //    var cacheItem = new CacheItem(key, Token);
            //    var cacheItemPolicy = new CacheItemPolicy
            //    {
            //        AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(99999)
            //    };
            //    _cache.Set(cacheItem, cacheItemPolicy);

            //}
            return Authorization = "Bearer  " + TestLogin("sadmin");

        }

        public static string TestLogin()
        {
            var loginRequest = new LoginRequestOwn { Email = "ssadmin@sipay.com.tr", Password = "Nop@ss1234" };
            //Arrange
            RestClient restClient = new RestClient(baseUrl);
            // Act
            var request = new RestRequest("api/v1/auth/login", Method.Post);

            request.AddJsonBody(loginRequest);

            RestResponse response = restClient.Execute(request);


            //// Assert
            LoginSuccessResponse aclResponse = JsonConvert.DeserializeObject<LoginSuccessResponse>(response.Content);

            return aclResponse.AccessToken;


        }
        
        public static string TestLogin(string sadmin)
        {
            var loginRequest = new LoginRequestOwn { Email = "mahmud@softrobotics.bd", Password = "secret" };
            //Arrange
            RestClient restClient = new RestClient(baseUrl);
            // Act
            var request = new RestRequest("api/v1/auth/login", Method.Post);

            request.AddJsonBody(loginRequest);

            RestResponse response = restClient.Execute(request);


            //// Assert
            LoginSuccessResponse aclResponse = JsonConvert.DeserializeObject<LoginSuccessResponse>(response.Content);

            return aclResponse.AccessToken;


        }


    }

    public class loginSuccessResonse()
    {

        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}