using ACL.Requests;
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Database.Models;
using ACL.Requests.V1;

namespace ACL.Tests.V1
{
    public class AclUserUnitTest
    {
        DatabaseConnector dbConnector;
        UnitOfWork unitOfWork;
        RestClient restClient;
        public AclUserUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new UnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public void TestUserList()
        {

            //Arrange

            // Act
            var request = new RestRequest("users", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void AddUserTest()
        {
            //Arrange
            var data = GetUser();

            // Act
            var request = new RestRequest("users/add", Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdUserTest()
        {
            //Arrange
            var id = getRandomID();

            // Act
            var request = new RestRequest($"users/view/{id}", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");


            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdUserTest()
        {
            //Arrange

            var data = GetUser();
            var id = getRandomID();

            // Act
            var request = new RestRequest($"users/edit/{id}", Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdUserTest()
        {

            var id = getRandomID();

            // Act
            var request = new RestRequest($"users/delete/{id}", Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclUserRequest GetUser()
        {
            var faker = new Faker();
            return new AclUserRequest
            {
                first_name = faker.Random.String2(1, 5),
                last_name = faker.Random.String2(1, 5),
                email = faker.Internet.Email(),
                password = faker.Random.String2(1, 5),
                avatar = faker.Random.String2(1, 50),
                dob = new DateTime(),
                gender = 1,
                address = faker.Random.String2(1, 30),
                city = faker.Random.String2(1, 10),
                country = 1,
                phone = "01524874555",
                username = faker.Random.String2(1, 5),
                img_path = faker.Random.String2(1, 10),
                status = 1,
                usergroup = new ulong[] { 1, 2 },
            };
        }

        private ulong getRandomID()
        {

            return unitOfWork.ApplicationDbContext.AclUsers.Max(x => x.Id);

        }

    }
}