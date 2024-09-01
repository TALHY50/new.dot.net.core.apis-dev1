using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Bogus;
using Newtonsoft.Json;
using RestSharp;
using SharedKernel.Main.Contracts;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.TEST
{
    public class AclBranchControllerUnitTest
    {
        RestClient restClient;
        public AclBranchControllerUnitTest()
        {
            DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void GetBranchList()
        {

            //Arrange
            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.List, Method.Get);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            RestResponse response = restClient.Execute(request);
            //Assert
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void PostAddBranch()
        {
            //Arrange
            var data = GetBranch();
            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.Add, Method.Post);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            request.AddJsonBody(data);
            RestResponse response = restClient.Execute(request);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void EditByIdBranchTest()
        {
            //Arrange

            var data = GetBranch();
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void GetByIdBranchTest()
        {
            //Arrange
            var id = GetRandomID();
            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            RestResponse response = restClient.Execute(request);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }

        [Fact]
        public void DeleteByIdBranchTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            RestResponse response = restClient.Execute(request);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

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

        private ulong GetRandomID()
        {

            return DataCollectors.dbContext.AclBranches.Max(x => x.Id);

        }
    }
}
