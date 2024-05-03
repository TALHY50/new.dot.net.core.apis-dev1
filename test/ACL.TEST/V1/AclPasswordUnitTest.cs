
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Newtonsoft.Json;
using ACL.Response.V1;
using ACL.Route;
using ACL.Requests.V1;
using SharedLibrary.Utilities;


namespace ACL.Tests.V1
{
    public class AclPasswordUnitTest
    {
        RestSharp.RestClient restClient;
        private string authToken;
        private ulong user_id = 2;
        private string userPassword = "Nop@ss1234";
        private string resetPassword = "Nop@ss4321";
        private string uniqueKey = "rest_cache_key";
        AclResponse aclResponse = new AclResponse();
        public AclPasswordUnitTest()
        {
            DataCollectors.SetDatabase();
            authToken = DataCollectors.GetAuthorization();
            restClient = new RestSharp.RestClient(DataCollectors.baseUrl);
            user_id = DataCollectors.unitOfWork.ApplicationDbContext.AclUsers.Max(x => x.Id);
        }
        [Fact]
        public void PasswordResetTest()
        {

            //Arrange
            var data = GetPasswordReset();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPasswordRouteUrl.Reset, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);
            RestResponse response = restClient.Execute(request);

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void PasswordForgetTest()
        {
            //Arrange
            var data = new AclForgetPasswordRequest { Email = DataCollectors.getRandomEmail() };

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPasswordRouteUrl.Forget, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);

            aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            CacheHelper.Set(uniqueKey, aclResponse.Data, 60);
            //SetMemoryCache((string)aclResponse.Data);

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void PasswordForgetVerifyTest()
        {
            //Arrange
            CacheHelper.Set(uniqueKey,authToken,1500);
            var data = new AclForgetPasswordTokenVerifyRequest
            {
                NewPassword = userPassword,
                PasswordConfirmation = userPassword,
                Token = (string)CacheHelper.Get(uniqueKey)
            };

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPasswordRouteUrl.VerifyToken, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);
            CacheHelper.Remove(uniqueKey);

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }


        private AclPasswordResetRequest GetPasswordReset()
        {
            user_id = DataCollectors.unitOfWork.ApplicationDbContext.AclUsers.Max(x => x.Id);
            return new AclPasswordResetRequest
            {
                UserId = user_id,
                CurrentPassword = userPassword,
                NewPassword = resetPassword,
                PasswordConfirmation = resetPassword
            };
        }


    }
}