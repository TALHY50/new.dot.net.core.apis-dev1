using ACL.Requests;
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
namespace ACL.Tests.V1
{
    public class AclStateUnitTest
    {
        DatabaseConnector dbConnector;
        CustomUnitOfWork unitOfWork;
        RestClient restClient;
        public AclStateUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new CustomUnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public void TestStateList()
        {

            //Arrange

            // Act
            var request = new RestRequest("states", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void AddStateTest()
        {
            //Arrange
            var data = GetState();

            // Act
            var request = new RestRequest("states/add", Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdStateTest()
        {
            //Arrange
            var id = getRandomID();

            // Act
            var request = new RestRequest($"states/view/{id}", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");


            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdStateTest()
        {
            //Arrange

            var data = GetState();
            var id = getRandomID();

            // Act
            var request = new RestRequest($"states/edit/{id}", Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdStateTest()
        {

            var id = getRandomID();

            // Act
            var request = new RestRequest($"states/delete/{id}", Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclStateRequest GetState()
        {
            var faker = new Faker();
            return new AclStateRequest
            {
                company_id = getRandomCompanyID(),
                country_id = getRandomCountryID(),
                name = faker.Random.String2(10, 50),
                description = faker.Random.String2(10, 255),
                sequence = (ulong)faker.Random.Number(1, int.MaxValue),
                status = (byte)faker.Random.Number(1, 2)

            };

        }

        private ulong getRandomID()
        {
            ulong id = 0;
            var states = unitOfWork.ApplicationDbContext.AclStates;
            if (states.Any())
            {
                id = states.Max(x => x.Id);
            }
            return id;

        }
        private ulong getRandomCompanyID()
        {
            ulong id = 0;
            var aclCompanies = unitOfWork.ApplicationDbContext.AclCompanies;
            if (aclCompanies.Any())
            {
                id = aclCompanies.Max(x => x.Id);
            }
            return id;
           
        }
        private ulong getRandomCountryID()
        {
            ulong id = 0;
            var aclCountries = unitOfWork.ApplicationDbContext.AclCountries;
            if (aclCountries.Any())
            {
                id = aclCountries.Max(x => x.Id);
            }
            return id;
        }

    }
}