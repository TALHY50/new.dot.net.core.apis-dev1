
using Microsoft.EntityFrameworkCore;
using RestSharp;
using ACL.Requests.V1;
using Newtonsoft.Json;
using ACL.Response.V1;
using SharedLibrary.Utilities;
using ACL.Route;

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
        public void PasswordResetTest()
        {

            //Arrange
            var data = GetPasswordReset();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPassword.Reset, Method.Post);
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
            var data = new AclForgetPasswordRequest { email = DataCollectors.getRandomEmail() };

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPassword.Forget, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);

            aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            CacheHelper.Set(uniqueKey,aclResponse.Data,60);
            //SetMemoryCache((string)aclResponse.Data);

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }
        [Fact]
        public void PasswordForgetVerifyTest()
        {
            //Arrange
            var data = new AclForgetPasswordTokenVerifyRequest { 
                new_password = userPassword, password_confirmation= userPassword, token = (string)CacheHelper.Get(uniqueKey)
        }; 

            // Act
            var request = new RestRequest(AclRoutesUrl.AclPassword.VerifyToken, Method.Post);
            request.AddHeader("Authorization", authToken);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);
            CacheHelper.Remove(uniqueKey);

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, (int)response.StatusCode);

        }


        private AclPasswordResetRequest GetPasswordReset()
        {
            return new AclPasswordResetRequest
            {
                user_id = user_id,
                current_password = userPassword ,
                new_password = resetPassword,
                password_confirmation = resetPassword
            };
        }

    
    }
}