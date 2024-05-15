using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response.V1;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Newtonsoft.Json;
using ACL.Route;
using SharedLibrary.Utilities;
using SharedLibrary.Services;
using SharedLibrary.Response.CustomStatusCode;

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
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); 
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
            string Token = (string)CacheHelper.Get(uniqueKey);
            if (!CacheHelper.Exist(uniqueKey))
            {
                Token = "bba47d83926a8d98cdc4affeee7b91459a08734b6e40da5ac0f69eaf78fb6017";
            }
            var data = new AclForgetPasswordTokenVerifyRequest
            {
                NewPassword = userPassword,
                PasswordConfirmation = userPassword,
                Token = Token
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
            var user = DataCollectors.unitOfWork.ApplicationDbContext.AclUsers.FirstOrDefault();
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