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
    public class AclUserUnitTest
    {
        RestClient restClient;
        string authToken;
        public AclUserUnitTest()
        {
            DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
             authToken = DataCollectors.GetAuthorization("sadmin");
        }
        [Fact]
        public void TestUserList()
        {

            //Arrange

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserRouteUrl.List, Method.Get);
            request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void AddUserTest()
        {
            //Arrange
            var data = GetUser();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserRouteUrl.Add, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);
            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void EditByIdUserTest()
        {
            //Arrange

            var data = GetUser();
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }
        [Fact]
        public void GetByIdUserTest()
        {
            //Arrange
            var id = GetRandomID();

            // Act
            //var request = new RestRequest($"users/view/{id}", Method.Get);
            var request = new RestRequest(AclRoutesUrl.AclUserRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
           request.AddHeader("Authorization", authToken);


            RestResponse response = restClient.Execute(request);

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }

        [Fact]
        public void DeleteByIdUserTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclUserRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
           request.AddHeader("Authorization", authToken);

            RestResponse response = restClient.Execute(request);

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ScopeResponse scopeResponse = JsonConvert.DeserializeObject<ScopeResponse>(response.Content);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(ApplicationStatusCodes.API_SUCCESS, scopeResponse.StatusCode);

        }

        private AclUserRequest GetUser()
        {
            var faker = new Faker();
            return new AclUserRequest
            {
                FirstName = faker.Random.String2(1, 5),
                LastName = faker.Random.String2(1, 5),
                Email = faker.Internet.Email(),
                Password = faker.Random.String2(1, 5),
                Avatar = faker.Random.String2(1, 50),
                DOB = DateTime.Now,
                Gender = 1,
                Address = faker.Random.String2(1, 30),
                City = faker.Random.String2(1, 10),
                Country = 1,
                Phone = "01524874555",
                UserName = faker.Random.String2(1, 5),
                ImgPath = faker.Random.String2(1, 10),
                Status = 1,
                UserGroup = new uint[] { 1, 2 },
            };
        }

        private uint GetRandomID()
        {

            //  var chkFirst = (uint)unitOfWork.UserRepository.FirstOrDefault().Result.Id;
            // var chkLast = (uint)unitOfWork.UserRepository.LastOrDefault().Result.Id;
            return (uint)DataCollectors.dbContext.AclUsers.Max(l => l.Id);

        }

    }
}