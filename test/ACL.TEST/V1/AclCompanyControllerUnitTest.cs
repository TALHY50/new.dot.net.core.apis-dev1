using ACL.Controllers.V1;
using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
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
    public class AclCompanyControllerUnitTest
    {
        DatabaseConnector dbConnector;
        CustomUnitOfWork unitOfWork;
        RestClient restClient;
        DbContextOptions<ApplicationDbContext> _inMemoryDbContextOptions;
        ApplicationDbContext _inMemoryDbContext;
        AclCompanyController controller;
        public AclCompanyControllerUnitTest()
        {
            dbConnector = new DatabaseConnector(true);
            _inMemoryDbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "acl")
                .Options;
            _inMemoryDbContext = new ApplicationDbContext(_inMemoryDbContextOptions);
            unitOfWork = new CustomUnitOfWork(_inMemoryDbContext);
            restClient = new RestClient(dbConnector.baseUrl);
            unitOfWork.ApplicationDbContext = _inMemoryDbContext;
           controller = new AclCompanyController(unitOfWork);
        }

        [Fact]
        public async Task Get_All_Companies()
        {
            #region  Arrange
            var chk = await getRandomID();
           
            #endregion
            #region Act
            var request = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.List, Method.Get);

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
            #region Arrange
            AclCompanyCreateRequest createReq = GetCompanyCreateRequest();
            #endregion

            #region Act
            //// Create request
            var req = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.Add, Method.Post);

            //// Serialize the request body
            req.AddJsonBody(createReq);

            //// Execute request
            var response = restClient.Execute(req);

            //// Convert actual status code to enum
            int actualCreateStatusCode = (int)response.StatusCode;
            #endregion

            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualCreateStatusCode);
            #endregion Assert
        }

        [Fact]

        public async Task Delete_Acl_Company()
        {
            #region  Arrange
            var id = getRandomID().Result;

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
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
        public async Task Put_Edit_Acl_Company()
        {
            #region  Arrange
            AclCompanyEditRequest editReq = GetCompanyEditRequest();
            var id = getRandomID().Result;
            #endregion
            #region Act
            //// Create request
            var req = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            //Add request body
            req.AddJsonBody(editReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = restClient.Execute(req);

            int actualEditStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualEditStatusCode);
            #endregion Assert
        }
        [Fact]

        public async Task Get_View_Company()
        {
            #region  Arrange
            var id = getRandomID().Result;
            #endregion

            #region Act
            var request = new RestRequest($"{AclRoutesUrl.AclCompanyRouteUrl.View.Replace("{id}", id.ToString())}", Method.Get);

            // request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            var response = restClient.Execute(request);
            #endregion

            #region Assert
            int actualStatusCode = (int)response.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);
            #endregion Assert
        }


        public AclCompanyCreateRequest GetCompanyCreateRequest()
        {
            var faker = new Faker();

            // Generate random data for the company creation request
            return new AclCompanyCreateRequest
            {
                name = faker.Company.CompanyName(),
                cname = faker.Company.CompanyName(),
                cemail = faker.Internet.Email(),
                address1 = faker.Address.StreetAddress(),
                address2 = faker.Address.SecondaryAddress(),
                city = faker.Random.String2(15),
                state = faker.Address.State(),
                country = faker.Address.Country(),
                postcode = faker.Address.ZipCode(),
                phone = faker.Random.String2(15),
                timezone = faker.Random.Number(-12, 12), // Convert to string if 'timezone' is a string
                timezone_value = faker.Random.String2(20),
                logo = faker.Image.PicsumUrl(),
                fax = faker.Random.String2(15),
                registration_no = faker.Random.AlphaNumeric(10),
                tax_no = faker.Random.AlphaNumeric(10),
                unique_column_name = (sbyte)faker.Random.Byte(), // Ensure 'unique_column_name' is of correct type
                email = faker.Internet.Email(),
                password = faker.Internet.Password()
            };
        }

        private AclCompanyEditRequest GetCompanyEditRequest()
        {
            var faker = new Faker();
            return new AclCompanyEditRequest
            {
                name = faker.Company.CompanyName(),
                cname = faker.Company.CompanyName(),
                cemail = faker.Internet.Email(),
                address1 = faker.Address.StreetAddress(),
                address2 = faker.Address.SecondaryAddress(),
                city = faker.Random.String2(15),
                state = faker.Address.State(),
                country = faker.Address.Country(),
                postcode = faker.Address.ZipCode(),
                phone = faker.Random.String2(15),
                timezone = faker.Random.Number(0, 24),
                unique_column_name = faker.Random.Number(1, 100),
                timezone_value = faker.Random.String2(20),
                logo = faker.Image.PicsumUrl(),
                fax = faker.Random.String2(15),
                registration_no = faker.Random.AlphaNumeric(10),
                tax_no = faker.Random.AlphaNumeric(10),
                status = (sbyte)faker.Random.Number(0, 1) // Example for status
            };

        }

        private async Task<ulong> getRandomID()
        {
            #region Arrange
            AclCompanyCreateRequest createReq = GetCompanyCreateRequest();
            #endregion

            

            #region Act
            // Act
            var aclResponse = await controller.Create(createReq);
            //var aclData = unitOfWork.AclCompanyRepository.Add((AclCompany)aclResponse.Data);
             // Commit the changes to the database
            await unitOfWork.CompleteAsync();
            var data = aclResponse.Data as AclCompany;

            return data.Id;
            #endregion
        }

    }
}

