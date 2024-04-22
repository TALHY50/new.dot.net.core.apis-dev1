using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Services;
using Bogus;
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

namespace ACL.TEST.V1
{
    [TestFixture]
    public class AclCompanyControllerUnitTest
    {
        private IUnitOfWork _unitOfWork;
        private DbContextOptions<ApplicationDbContext> _inMemoryDbContext;
        private ApplicationDbContext _dbContext;
        public AclCompanyControllerUnitTest(IUnitOfWork unitOfWork)
        {
            _inMemoryDbContext = new DbContextOptionsBuilder<ApplicationDbContext>()
                         .UseInMemoryDatabase(databaseName: "acl")
                         .Options;
            _dbContext = new ApplicationDbContext(_inMemoryDbContext);
            _unitOfWork = unitOfWork = new UnitOfWork(_dbContext);
        }



        public async Task Get_All_Returns_The_Correct_Number_Of_Acompanies()
        {
            #region  Arrange
            var data = GetCompanyCreateRequest();
            var id = getRandomID();
            // Create RestClient
            var client = new RestSharp.RestClient("https://localhost:7125/api/v1");

            using (var dbContext = new ApplicationDbContext(_inMemoryDbContext))
            {
                // Populate the in-memory database with test data
                dbContext.AclCompanies.AddRange(new List<AclCompany>
            {
                new AclCompany{ Id = 1,AddedBy = 1,Address1 ="A",Address2 ="B",AverageTurnover=2.0,Cemail ="",City ="Dhaka",CmmiLevel = 1,Cname ="Porosh",Country="BD",Email="porosh@gmail.com",Fax="",Logo="",Name="Porosh",Phone="01672896992" ,Postcode ="1312",RegistrationNo="1234",State = "1",TaxNo="123456789",Timezone =1,TimezoneValue ="1",Status=1}
            });
                dbContext.SaveChanges();
            }

            AclCompanyCreateRequest createReq = GetCompanyCreateRequest();

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest("/companies/add", Method.Post);
            //Add request body
            req.AddBody(createReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = client.Execute(req);

            //// Convert actual status code to enum
            int actualCreateStatusCode = (int)respons.StatusCode;
            //// Assert for create
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualCreateStatusCode);
            #endregion
            #region Assert
            //// Create request
            var request = new RestRequest("/companies", Method.Get);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var response = client.Execute(request);

            //// Convert actual status code to enum
            int actualStatusCode = (int)response.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);
            #endregion Assert

        }
        public async Task Post_Add_Acl_Company()
        {
            #region  Arrange
            var data = GetCompanyCreateRequest();
            var id = getRandomID();
            // Create RestClient
            var client = new RestSharp.RestClient("https://localhost:7125/api/v1");

            using (var dbContext = new ApplicationDbContext(_inMemoryDbContext))
            {
                // Populate the in-memory database with test data
                dbContext.AclCompanies.AddRange(new List<AclCompany>
            {
                new AclCompany{ Id = 1,AddedBy = 1,Address1 ="A",Address2 ="B",AverageTurnover=2.0,Cemail ="",City ="Dhaka",CmmiLevel = 1,Cname ="Porosh",Country="BD",Email="porosh@gmail.com",Fax="",Logo="",Name="Porosh",Phone="01672896992" ,Postcode ="1312",RegistrationNo="1234",State = "1",TaxNo="123456789",Timezone =1,TimezoneValue ="1",Status=1}
            });
                dbContext.SaveChanges();
            }

            AclCompanyCreateRequest createReq = GetCompanyCreateRequest();

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest("/companies/add", Method.Post);
            //Add request body
            req.AddBody(createReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = client.Execute(req);

            //// Convert actual status code to enum
            int actualCreateStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualCreateStatusCode);
            #endregion Assert
        }
        
        public async Task Delete_Delete_Acl_Company()
        {
            #region  Arrange
            AclCompanyEditRequest data = GetCompanyEditRequest();
            var id = getRandomID();
            // Create RestClient
            var client = new RestSharp.RestClient("https://localhost:7125/api/v1");

            using (var dbContext = new ApplicationDbContext(_inMemoryDbContext))
            {
                // Populate the in-memory database with test data
                dbContext.AclCompanies.AddRange(new List<AclCompany>
            {
                new AclCompany{ Id = 1,AddedBy = 1,Address1 ="A",Address2 ="B",AverageTurnover=2.0,Cemail ="",City ="Dhaka",CmmiLevel = 1,Cname ="Porosh",Country="BD",Email="porosh@gmail.com",Fax="",Logo="",Name="Porosh",Phone="01672896992" ,Postcode ="1312",RegistrationNo="1234",State = "1",TaxNo="123456789",Timezone =1,TimezoneValue ="1",Status=1}
            });
                dbContext.SaveChanges();
            }

            AclCompanyEditRequest editReq = GetCompanyEditRequest();

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest("/companies/edit/{id}", Method.Put);
            //Add request body
            req.AddBody(editReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = client.Execute(req);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualEditStatusCode);
            #endregion Assert
        } public async Task Put_Edit_Acl_Company()
        {
            #region  Arrange
            AclCompanyEditRequest data = GetCompanyEditRequest();
            var id = getRandomID();
            // Create RestClient
            var client = new RestSharp.RestClient("https://localhost:7125/api/v1");

            using (var dbContext = new ApplicationDbContext(_inMemoryDbContext))
            {
                // Populate the in-memory database with test data
                dbContext.AclCompanies.AddRange(new List<AclCompany>
            {
                new AclCompany{ Id = 1,AddedBy = 1,Address1 ="A",Address2 ="B",AverageTurnover=2.0,Cemail ="",City ="Dhaka",CmmiLevel = 1,Cname ="Porosh",Country="BD",Email="porosh@gmail.com",Fax="",Logo="",Name="Porosh",Phone="01672896992" ,Postcode ="1312",RegistrationNo="1234",State = "1",TaxNo="123456789",Timezone =1,TimezoneValue ="1",Status=1}
            });
                dbContext.SaveChanges();
            }

            AclCompanyEditRequest editReq = GetCompanyEditRequest();

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest("/companies/edit/{id}", Method.Put);
            //Add request body
            req.AddBody(editReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = client.Execute(req);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualEditStatusCode);
            #endregion Assert
        }

        private AclCompanyCreateRequest GetCompanyCreateRequest()
        {
            var faker = new Faker();
            string json = @"
        {
            ""name"": ""Mahmud"",
            ""cname"": ""Test Company"",
            ""cemail"": ""mahmud@gmail.com"",
            ""address1"": ""asdfa sdfasdf"",
            ""address2"": ""asdf asdfsadf"",
            ""city"": ""Dahka"",
            ""state"": ""Dhaka"",
            ""country"": ""Bangladesh"",
            ""postcode"": ""1229"",
            ""phone"": ""01521497833"",
            ""timezone"": -11,
            ""timezone_value"": ""asdfasdf"",
            ""logo"": ""asdfasdfasdf.png"",
            ""fax"": ""asdfasdf"",
            ""registration_no"": ""asdfasdf"",
            ""tax_no"": ""asdfasdf"",
            ""unique_column_name"": 1,
            ""email"": ""korim@gmail.com"",
            ""password"": ""secret""
        }";

            return JsonConvert.DeserializeObject<AclCompanyCreateRequest>(json);


        }
        private AclCompanyEditRequest GetCompanyEditRequest()
        {
            var faker = new Faker();
            string json = @"
        {
            ""name"": ""Mahmud1"",
            ""cname"": ""Test Company1"",
            ""cemail"": ""mahmud@gmail.com"",
            ""address1"": ""asdfa sdfasdf"",
            ""address2"": ""asdf asdfsadf"",
            ""city"": ""Dahka"",
            ""state"": ""Dhaka"",
            ""country"": ""Bangladesh"",
            ""postcode"": ""1229"",
            ""phone"": ""01521497833"",
            ""timezone"": 12,
            ""unique_column_name"": 1,
            ""timezone_value"": ""UTC+"",
            ""logo"": ""asdfasdfasdf.png"",
            ""fax"": ""asdfasdf"",
            ""registration_no"": ""asdfasdf"",
            ""tax_no"": ""asdfasdf"",
            ""status"": 1
        }";

            return JsonConvert.DeserializeObject<AclCompanyEditRequest>(json);

        }

        private ulong getRandomID()
        {
            return _unitOfWork.AclCompanyRepository.FirstOrDefault().Result.Id;

        }
    }
}
