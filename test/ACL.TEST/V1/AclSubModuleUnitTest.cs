using ACL.Requests;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Route;
using ACL.Database.Models;

namespace ACL.Tests.V1
{
    public class AclSubModuleUnitTest
    {
        RestClient restClient;
        string authToken;
        public AclSubModuleUnitTest()
        {
            DataCollectors.SetDatabase();
            authToken = DataCollectors.GetAuthorization();
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void TestSubModuleList()
        {

            //Arrange

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubModule.List, Method.Get);
            request.AddHeader("Authorization", authToken);
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
            var request = new RestRequest(AclRoutesUrl.AclSubModule.Add, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdSubModuleTest()
        {
            //Arrange
            var id = DataCollectors.GetMaxId<AclSubModule>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubmodule.View.Replace("{id}", id.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdSubModuleTest()
        {
            //Arrange

            var data = GetSubModule();
            var id = DataCollectors.GetMaxId<AclSubModule>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubmodule.Edit.Replace("{id}", id.ToString()), Method.Put);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdSubModuleTest()
        {

            var id = DataCollectors.GetMaxId<AclSubModule>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclSubmodule.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclSubModuleRequest GetSubModule()
        {
            var faker = new Faker();
            return new AclSubModuleRequest
            {
                id = (ulong)faker.Random.Number(1, int.MaxValue),
                module_id = DataCollectors.GetMaxId<AclModule>(x => x.Id),
                name = faker.Random.String2(10, 50),
                controller_name = faker.Random.String2(10, 50),
                default_method = faker.Random.String2(10, 50),
                display_name = faker.Random.String2(10, 50),
                sequence = faker.Random.Number(1, int.MaxValue),
                icon = faker.Random.String2(10, 100)

            };

        }



    }
}