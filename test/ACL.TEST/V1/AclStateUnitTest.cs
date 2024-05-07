using ACL.Requests;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Bogus;
using ACL.Route;
using ACL.Database.Models;
using SharedLibrary.Response.CustomStatusCode;
using ACL.Response.V1;
using Newtonsoft.Json;

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
            var request = new RestRequest(AclRoutesUrl.AclStateRouteUrl.List, Method.Get);
            //request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);

            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void AddStateTest()
        {
            //Arrange
            var data = GetState();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclStateRouteUrl.Add, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);

            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        [Fact]
        public void EditByIdStateTest()
        {
            //Arrange

            var data = GetState();
            var id = DataCollectors.unitOfWork.ApplicationDbContext.AclStates.Max(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclStateRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);

            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void GetByIdStateTest()
        {
            //Arrange
            var id = DataCollectors.GetMaxId<AclState>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclStateRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);

            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void DeleteByIdStateTest()
        {

            var id = DataCollectors.GetMaxId<AclState>(x => x.Id);

            // Act
            var request = new RestRequest(AclRoutesUrl.AclStateRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            request.AddHeader("Authorization", authToken);
            RestResponse response = restClient.Execute(request);

            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        private AclStateRequest GetState()
        {
            var faker = new Faker();
            return new AclStateRequest
            {
                CompanyId = DataCollectors.GetMaxId<AclCompany>(x => x.Id),
                CountryId = DataCollectors.GetMaxId<AclCountry>(x => x.Id),
                Name = faker.Random.String2(10, 50),
                Description = faker.Random.String2(10, 255),
                Sequence = (ulong)faker.Random.Number(1, int.MaxValue),
                Status = (byte)faker.Random.Number(1, 2)

            };

        }


    }
}