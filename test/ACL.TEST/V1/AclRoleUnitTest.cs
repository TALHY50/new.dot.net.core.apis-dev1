using ACL.Interfaces;
using ACL.Requests;
using ACL.Services;
using Bogus;
using NUnit.Framework;
using RestSharp;

namespace ACL.Tests
{
    [TestFixture]
    public class AclRoleUnitTest
    {
        //private  IUnitOfWork _unitOfWork;

        //public AclRoleUnitTest(IUnitOfWork unitOfWork) 
        //{
        //    _unitOfWork = unitOfWork;
        //}

        [Fact]
        public async void GetAllRolesTest()
        {
            var data = GetRole();
            //var id = getRandomID();
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

        //private ulong getRandomID()
        //{
        //    return _unitOfWork.ApplicationDbContext.AclRoles.FirstOrDefault().Id;

        //}
    }
}