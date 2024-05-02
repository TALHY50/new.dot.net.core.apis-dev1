using ACL.Requests;
using ACL.Requests.V1;
using ACL.Services;
using ACL.Tests;
using Bogus;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.TEST.V1
{
    public class AclBranchControllerUnitTest
    {
        DatabaseConnector dbConnector;
        CustomUnitOfWork unitOfWork;
        RestClient restClient;
        public AclBranchControllerUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new CustomUnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public void GetBranchList()
        {

            //Arrange
            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclBranchRouteUrl.List, Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");
            RestResponse response = restClient.Execute(request);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void PostAddBranch()
        {
            //Arrange
            var data = GetBranch();
            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclBranchRouteUrl.Add, Method.Post);
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
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclBranchRouteUrl.View.Replace("{id}",id.ToString()), Method.Get);
            //request.AddHeader("Authorization", "Bearer desc");
            RestResponse response = restClient.Execute(request);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdCountryTest()
        {
            //Arrange

            var data = GetBranch();
            var id = getRandomID();

            // Act
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclBranchRouteUrl.Edit.Replace("{id}",id.ToString()), Method.Put);
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
            var request = new RestRequest(ACL.Route.AclRoutesUrl.AclBranchRouteUrl.Destroy.Replace("{id}",id.ToString()), Method.Delete);
            //request.AddHeader("Authorization", "Bearer desc");

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclBranchRequest GetBranch()
        {
            var faker = new Faker();
            return new AclBranchRequest
            {
                Name = faker.Random.String2(10, 50),
                Address = faker.Random.String2(10, 100),
                Description = faker.Random.String2(2, 5),
                Status = (byte)faker.Random.Number(1, 2),
                Sequence = (ulong)faker.Random.Number(10, 200),
            };

        }

        private ulong getRandomID()
        {

            return unitOfWork.ApplicationDbContext.AclCountries.Max(x => x.Id);

        }
    }
}
