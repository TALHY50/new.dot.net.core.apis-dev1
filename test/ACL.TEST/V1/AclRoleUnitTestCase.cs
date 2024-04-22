using ACL.Requests;
using ACL.Services;
using Bogus;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace ACL.Tests
{
    public class AclRoleUnitTestCase
    {
        DatabaseConnector dbConnector;
        UnitOfWork unitOfWork;
        RestClient restClient;
        public AclRoleUnitTestCase()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new UnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public void TestRoleList()
        {

            //Arrange

            // Act
            var request = new RestRequest("roles", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

          
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void AddRoleTest()
        {
            //Arrange
            var data = GetRole();

            // Act
            var request = new RestRequest("roles/add", Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdRoleTest()
        {
            //Arrange
            var id = getRandomID();

            // Act
            var request = new RestRequest($"roles/view/{id}", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");
           

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdRoleTest()
        {
            //Arrange

            var data = GetRole();
            var id = getRandomID();

            // Act
            var request = new RestRequest($"roles/edit/{id}", Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdRoleTest()
        {

            var id = getRandomID();

            // Act
            var request = new RestRequest($"roles/delete/{id}", Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclRoleRequest GetRole()
        {
            var faker = new Faker();
            return new AclRoleRequest
            {
                name = faker.Lorem.Sentence(5),
                status = (sbyte)faker.Random.Number(1, 2),
                title = faker.Lorem.Sentence(5)
            };

        }

        private ulong getRandomID()
        {

            return unitOfWork.ApplicationDbContext.AclRoles.FirstOrDefault().Id;

        }

    }
}