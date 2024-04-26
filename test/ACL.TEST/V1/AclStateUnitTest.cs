using ACL.Requests;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Route;
using ACL.Database.Models;

namespace ACL.Tests.V1
{
    public class AclStateUnitTest
    {
        RestClient restClient;
        private string authToken;
        public AclStateUnitTest()
        {
            authToken = DataCollectors.GetAuthorization();
            DataCollectors.SetDatabase();
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void TestStateList()
        {

            //Arrange

            // Act
            var request = new RestRequest(AclRoutesUrl.AclState.List, Method.Get);
            request.AddHeader("Authorization", authToken);
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
            var request = new RestRequest(AclRoutesUrl.AclState.Add, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        [Fact]
        public void GetByIdStateTest()
        {
            //Arrange
            var id = DataCollectors.GetMaxId<AclState>(x => x.Id); 

            // Act
            var request = new RestRequest(AclRoutesUrl.AclState.View.Replace("{id}", id.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void EditByIdStateTest()
        {
            //Arrange

            var data = GetState();
            var id = DataCollectors.GetMaxId<AclState>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclState.Edit.Replace("{id}", id.ToString()), Method.Put);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void DeleteByIdStateTest()
        {

            var id = DataCollectors.GetMaxId<AclState>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclState.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }

        private AclStateRequest GetState()
        {
            var faker = new Faker();
            return new AclStateRequest
            {
                company_id = DataCollectors.GetMaxId<AclCompany>(x => x.Id),
                country_id = DataCollectors.GetMaxId<AclCountry>(x => x.Id),
                name = faker.Random.String2(10, 50),
                description = faker.Random.String2(10, 255),
                sequence = (ulong)faker.Random.Number(1, int.MaxValue),
                status = (byte)faker.Random.Number(1, 2)

            };

        }

       
    }
}