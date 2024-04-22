using ACL.Database;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Services;
using Bogus;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RestSharp;
using System.Data.Common;

namespace ACL.Tests
{
    [TestFixture]
    public class AclRoleUnitTest
    {
        private IUnitOfWork _unitOfWork;
        private DbContextOptions<ApplicationDbContext> _inMemoryDbContext;

        public AclRoleUnitTest(IUnitOfWork unitOfWork)
        {
            _inMemoryDbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                         .UseInMemoryDatabase(databaseName: "acl")
                         .Options;
            var dbContext = new ApplicationDbContext(_inMemoryDbContext);
            _unitOfWork = unitOfWork = new UnitOfWork(dbContext);
        }


        [Fact]
        public async void GetAllRolesTest()
        {
            var data = GetRole();
            var id = getRandomID();
            // Create RestClient
            var client = new RestSharp.RestClient("https://localhost:7125/api/v1");

            //// Create request
            var request = new RestRequest("/roles", Method.Get);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var response = client.Execute(request);

            //// Convert actual status code to enum
            int actualStatusCode = (int)response.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);

        }

        private AclRoleRequest GetRole()
        {
            var faker = new Faker();
            return new AclRoleRequest
            {
                name = faker.Lorem.Sentence(100),
                status = (sbyte)faker.Random.Number(1, 2),
                title = faker.Lorem.Sentence(100)
            };

        }

        private ulong getRandomID()
        {
            return _unitOfWork.ApplicationDbContext.AclRoles.FirstOrDefault().Id;

        }
    }
}