using ACL.Requests;
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
namespace ACL.Tests.V1
{
    public class AclSubModuleUnitTest
    {
        DatabaseConnector dbConnector;
        CustomUnitOfWork unitOfWork;
        RestClient restClient;
        public AclSubModuleUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new CustomUnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public void TestSubModuleList()
        {

            //Arrange

            // Act
            var request = new RestRequest("submodules", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

          
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void AddSubModuleTest()
        {
            //Arrange
            var data = GetSubModule();

            // Act
            var request = new RestRequest("submodules/add", Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdSubModuleTest()
        {
            //Arrange
            var id = getRandomID();

            // Act
            var request = new RestRequest($"submodules/view/{id}", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");
           

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdSubModuleTest()
        {
            //Arrange

            var data = GetSubModule();
            var id = getRandomID();

            // Act
            var request = new RestRequest($"submodules/edit/{id}", Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdSubModuleTest()
        {

            var id = getRandomID();

            // Act
            var request = new RestRequest($"submodules/delete/{id}", Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclSubModuleRequest GetSubModule()
        {
            var faker = new Faker();
            return new AclSubModuleRequest
            {
                id = (ulong)faker.Random.Number(1,int.MaxValue),
                module_id = getRandomModuleID(),
                name = faker.Random.String2(10,50),
                controller_name = faker.Random.String2(10, 50),
                default_method = faker.Random.String2(10, 50),
                display_name = faker.Random.String2(10, 50),
                sequence = faker.Random.Number(1,int.MaxValue),
                icon = faker.Random.String2(10, 100)

            };

        }

        private ulong getRandomID()
        {
            return unitOfWork.ApplicationDbContext.AclSubModules.Max(x=>x.Id);

        }
        private ulong getRandomModuleID()
        {

            return unitOfWork.ApplicationDbContext.AclModules.FirstOrDefault().Id;

        }

    }
}