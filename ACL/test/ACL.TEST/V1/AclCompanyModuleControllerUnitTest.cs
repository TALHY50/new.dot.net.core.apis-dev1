using ACL.Tests;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SharedLibrary.Response.CustomStatusCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using static ACL.Infrastructure.Route.AclRoutesUrl;


namespace ACL.Tests.V1
{
    public class AclCompanyModuleControllerUnitTest
    {

        RestClient restClient;
        public AclCompanyModuleControllerUnitTest()
        {
            DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public async Task Get_All_CompanyModules()
        {
            #region  Arrange

            AclCompanyModuleRequest createReq = GetCompanyModuleRequest();

            #endregion
            #region Act
            var request = new RestRequest(AclRoutesUrl.AclCompanyModuleRouteUrl.List, Method.Get);

            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            var response = restClient.Execute(request);
            #endregion
            #region Assert


            //// Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
            #endregion Assert

        }
        [Fact]
        public async Task Post_Add_Acl_Company()
        {
            #region  Arrange
            AclCompanyModuleRequest createReq = GetCompanyModuleRequest();

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest(AclRoutesUrl.AclCompanyModuleRouteUrl.Add, Method.Post);
            //Add request body
            req.AddBody(createReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var response = restClient.Execute(req);

            //// Convert actual status code to enum

            #endregion
            #region Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
            #endregion Assert
        }
        [Fact]
        public async Task Put_Edit_Acl_CompanyModule()
        {
            #region  Arrange
            AclCompanyModuleRequest editReq = GetCompanyModuleRequest();
            var id = GetRandomID();
            #endregion
            #region Act
            //// Create request
            var request = new RestRequest(AclCompanyModuleRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);

            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            //Add request body
            request.AddBody(editReq);

            //// Execute request
            var response = restClient.Execute(request);


            #endregion
            #region Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
            #endregion Assert
        }
        [Fact]
        public async Task Get_View_CompanyModule()
        {
            #region  Arrange
            var id = GetRandomID();
            #endregion
            #region Act
            var request = new RestRequest(AclCompanyModuleRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);

            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            var response = restClient.Execute(request);
            #endregion
            #region Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
            #endregion Assert

        }

        [Fact]
        public async Task Delete_Acl_Company()
        {
            #region  Arrange
            var id = GetRandomID();
            //// Create RestClient
            //var client = new RestSharp.RestClient("https://localhost:7125/api/v1");

            ////using (var dbContext = new ApplicationDbContext(_inMemoryDbContext))
            ////{
            ////    // Populate the in-memory database with test data
            ////    dbContext.AclCompanies.AddRange(new List<AclCompany>
            ////{
            ////    new AclCompany{ Id = 1,AddedBy = 1,Address1 ="A",Address2 ="B",AverageTurnover=2.0,Cemail ="",City ="Dhaka",CmmiLevel = 1,Cname ="Porosh",Country="BD",Email="porosh@gmail.com",Fax="",Logo="",Name="Porosh",Phone="01672896992" ,Postcode ="1312",RegistrationNo="1234",State = "1",TaxNo="123456789",Timezone =1,TimezoneValue ="1",Status=1}
            ////});
            ////    dbContext.SaveChanges();
            ////}


            #endregion
            #region Act
            //// Create request
            var request = new RestRequest(AclCompanyModuleRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            //Add request body
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            //// Execute request
            var response = restClient.Execute(request);

            #endregion
            #region Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);
            #endregion Assert
        }


        public AclCompanyModuleRequest GetCompanyModuleRequest()
        {
            // Generate random data for the company module request
            return new AclCompanyModuleRequest
            {
                CompanyId = DataCollectors.dbContext.AclCompanies.Max(i => i.Id),
                ModuleId = DataCollectors.dbContext.AclModules.Max(i => i.Id)
            };
        }


        private ulong GetRandomID()
        {
            #region Act
            //    // Act
            //return dbContext.AclCompanyModules.Last().Id;
            return (ulong)DataCollectors.dbContext.AclCompanyModules.Max(i => i.Id);
            #endregion
            // }

        }
    }
}

