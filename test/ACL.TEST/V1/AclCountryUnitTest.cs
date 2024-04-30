using ACL.Requests;
using ACL.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Database.Models;
using ACL.Requests.V1;
using SharedLibrary.Services;

namespace ACL.Tests.V1
{
    public class AclCountryUnitTest
    {
        DatabaseConnector dbConnector;
        CustomUnitOfWork unitOfWork;
        RestClient restClient;
        public AclCountryUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new CustomUnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public void TestCountryList()
        {

            //Arrange
            // Act
            var request = new RestRequest("countries", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");
            RestResponse response = restClient.Execute(request);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void AddCountryTest()
        {
            //Arrange
            var data = GetCountry();
            // Act
            var request = new RestRequest("countries/add", Method.Post);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);
            RestResponse response = restClient.Execute(request);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdCountryTest()
        {
            //Arrange
            var id = getRandomID();
            // Act
            var request = new RestRequest($"countries/view/{id}", Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");
            RestResponse response = restClient.Execute(request);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdCountryTest()
        {
            //Arrange

            var data = GetCountry();
            var id = getRandomID();

            // Act
            var request = new RestRequest($"countries/edit/{id}", Method.Put);
            //request.AddHeader("Authorization", "Bearer desc");
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdCountryTest()
        {

            var id = getRandomID();

            // Act
            var request = new RestRequest($"countries/delete/{id}", Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclCountryRequest GetCountry()
        {
            var faker = new Faker();
            return new AclCountryRequest
            {
                name = faker.Random.String2(10, 50),
                description = faker.Random.String2(10, 100),
                code = faker.Random.String2(2, 5),
                status = (byte)faker.Random.Number(1, 2),
                sequence = (ulong)faker.Random.Number(10, 200),
            };

        }

        private ulong getRandomID()
        {

            return unitOfWork.ApplicationDbContext.AclCountries.Max(x => x.Id);

        }

    }
}