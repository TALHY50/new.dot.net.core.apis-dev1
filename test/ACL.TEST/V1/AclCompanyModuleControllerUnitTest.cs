using ACL.Controllers.V1;
using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Services;
using ACL.Tests;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Tests.V1
{
    public class AclCompanyModuleControllerUnitTest
    {
        DatabaseConnector dbConnector;
        UnitOfWork unitOfWork;
        RestClient restClient;
        DbContextOptions<ApplicationDbContext> _inMemoryDbContext;
        public AclCompanyModuleControllerUnitTest()
        {
            dbConnector = new DatabaseConnector();
            _inMemoryDbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
      .UseInMemoryDatabase(databaseName: "acl")
      .Options;
            //unitOfWork = new UnitOfWork(new ApplicationDbContext(_inMemoryDbContext));
            unitOfWork = new UnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public async Task Get_All_CompanyModules()
        {
            #region  Arrange

            AclCompanyModuleRequest createReq = GetCompanyModuleRequest();

            #endregion
            #region Act
            var request = new RestRequest("/company/modules", Method.Get);

            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            var response = restClient.Execute(request);
            #endregion
            #region Assert


            //// Convert actual status code to enum
            int actualStatusCode = (int)response.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);
            #endregion Assert

        }
        [Fact]
        public async Task Post_Add_Acl_Company()
        {
            #region  Arrange
            //var id = getRandomID();
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

            AclCompanyModuleRequest createReq = GetCompanyModuleRequest();

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest("/company/modules/add", Method.Post);
            //Add request body
            req.AddBody(createReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = restClient.Execute(req);

            //// Convert actual status code to enum
            int actualCreateStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualCreateStatusCode);
            #endregion Assert
        }
        [Fact]

        public async Task Delete_Acl_Company()
        {
            #region  Arrange
            var id = getRandomID();
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
            var req = new RestRequest("/company/modules/delete/" + id, Method.Delete);
            //Add request body

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = restClient.Execute(req);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualEditStatusCode);
            #endregion Assert
        }
        [Fact]
        public async Task Put_Edit_Acl_CompanyModule()
        {
            #region  Arrange
            AclCompanyModuleRequest editReq = GetCompanyModuleRequest();
            var id = getRandomID();
            //// Create RestClient
            //var client = new RestSharp.RestClient("https://localhost:7125/api/v1");




            #endregion
            #region Act
            //// Create request
            var req = new RestRequest("/company/modules/edit/" + id, Method.Put);
            //Add request body
            req.AddBody(editReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = restClient.Execute(req);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualEditStatusCode);
            #endregion Assert
        }
        [Fact]

        public async Task Get_View_CompanyModule()
        {
            #region  Arrange
            var id = getRandomID();
            // AclCompanyCreateRequest createReq = GetCompanyCreateRequest();

            #endregion
            #region Act
            var request = new RestRequest("/company/modules/view/" + id, Method.Get);

            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            var response = restClient.Execute(request);
            #endregion
            #region Assert


            //// Convert actual status code to enum
            int actualStatusCode = (int)response.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);
            #endregion Assert

        }

        public AclCompanyModuleRequest GetCompanyModuleRequest()
        {
            var faker = new Faker();
            var random = new Random();

            // Generate random ulong values within the valid range
            ulong GenerateRandomUlong()
            {
                var buffer = new byte[sizeof(ulong)];
                random.NextBytes(buffer);
                return BitConverter.ToUInt64(buffer, 0);
            }

            // Generate random data for the company module request
            return new AclCompanyModuleRequest
            {
                company_id = GenerateRandomUlong(),
                module_id = GenerateRandomUlong()
            };
        }


        private ulong getRandomID()
        {

            //using (var dbContext = (dbConnector.dbContext))
            //{
            //    // Use a genuine instance of UnitOfWork
            //    var unitOfWork = new UnitOfWork(dbContext);
            //    unitOfWork.ApplicationDbContext = dbContext;
            //    // unitOfWork.LocalizationService = 
            //    var controller = new AclCompanyController(unitOfWork);
            #region Act
            //    // Act
            //    return (ulong)controller._unitOfWork.AclCompanyRepository.FirstOrDefault().Id;
            return unitOfWork.ApplicationDbContext.AclCompanyModules.Last().Id;
            #endregion
            // }

        }
    }
}

