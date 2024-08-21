using ACL.App.Infrastructure.Route;
using Newtonsoft.Json;
using RestSharp;
using SharedKernel.Main.Contracts.ACL.Contracts.Requests;
using SharedKernel.Main.Contracts.ACL.Contracts.Response;
using SharedKernel.Main.Contracts.Response;
using SharedKernel.Main.Infrastructure.Services;
using SharedKernel.Main.Infrastructure.Utilities;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8601 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0414 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS1998 // Converting null literal or possible null value to non-nullable type.
namespace ACL.TEST
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
            authToken = DataCollectors.GetAuthorization("sadmin");
            restClient = new RestSharp.RestClient(DataCollectors.baseUrl);
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

            //// Assert
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); 
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void PasswordResetTest()
        {

            //Arrange
            var data = GetPasswordReset();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPasswordRouteUrl.Forget, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);

            aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);

            CacheHelper.Set(uniqueKey, aclResponse.Data, 120);

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        [Fact]
        public void PasswordForgetVerifyTest()
        {
            //Arrange
            var data = new AclForgetPasswordTokenVerifyRequest
            {
                NewPassword = userPassword,
                PasswordConfirmation = userPassword,
                Token = authToken
            };

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPasswordRouteUrl.VerifyToken, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);
            aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            CacheHelper.Remove(uniqueKey);

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }


        private AclPasswordResetRequest GetPasswordReset()
        {
            AclPasswordResetRequest aclPassword = new AclPasswordResetRequest();
            var user = DataCollectors.dbContext.AclUsers.FirstOrDefault();
            if (user != null)
            {
                aclPassword.UserId = user.Id;
                aclPassword.CurrentPassword = Cryptographer.AppDecrypt(user.Password);
                aclPassword.NewPassword = resetPassword;
                aclPassword.PasswordConfirmation = resetPassword;
            }
            return aclPassword;
        }


    }
}