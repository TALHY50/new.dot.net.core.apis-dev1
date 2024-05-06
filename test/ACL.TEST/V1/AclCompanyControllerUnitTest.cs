﻿using ACL.Controllers.V1;
using ACL.Database;
using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using ACL.Services;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SharedLibrary.Response.CustomStatusCode;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACL.Tests.V1
{
    public class AclCompanyControllerUnitTest
    {
        RestClient restClient;
        public AclCompanyControllerUnitTest()
        {
              DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }

        [Fact]
        public async Task Get_All_Companies()
        {
            #region  Arrange
            //var chk = await getRandomID();

            #endregion
            #region Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.List, Method.Get);

            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            var response = restClient.Execute(request);
            #endregion
            #region Assert

            //// Convert actual status code to enum
            int actualStatusCode = (int)response.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, actualStatusCode);
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
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content); 
            #endregion

            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, actualCreateStatusCode);
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
            var req = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            //Add request body

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var response = restClient.Execute(req);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)response.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, actualEditStatusCode);
            #endregion Assert
        }
        [Fact]
        public async Task Put_Edit_Acl_Company()
        {
            #region  Arrange
            AclCompanyEditRequest editReq = GetCompanyEditRequest();
            var id = getRandomID().Id;
            #endregion
            #region Act
            //// Create request
            var req = new RestRequest(AclRoutesUrl.AclCompanyRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            //Add request body
            req.AddJsonBody(editReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var response = restClient.Execute(req);

            int actualEditStatusCode = (int)response.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, actualEditStatusCode);
            #endregion Assert
        }
        [Fact]

        public async Task Get_View_Company()
        {
            #region  Arrange
            var id = getRandomID().Id;
            #endregion

            #region Act
            var request = new RestRequest($"{AclRoutesUrl.AclBranchRouteUrl.View.Replace("{id}", id.ToString())}", Method.Get);

            // request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            var response = restClient.Execute(request);
            #endregion

            #region Assert
            int actualStatusCode = (int)response.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, actualStatusCode);
            #endregion Assert
        }


        public AclCompanyCreateRequest GetCompanyCreateRequest()
        {
            var faker = new Faker();

            // Generate random data for the company creation request
            return new AclCompanyCreateRequest
            {
                Name = faker.Company.CompanyName(),
                Cname = faker.Company.CompanyName(),
                Cemail = faker.Internet.Email(),
                Address1 = faker.Address.StreetAddress(),
                Address2 = faker.Address.SecondaryAddress(),
                City = faker.Random.String2(15),
                State = faker.Address.State(),
                Country = faker.Address.Country(),
                PostCode = faker.Address.ZipCode(),
                Phone = faker.Random.String2(15),
                Timezone = faker.Random.Number(-12, 12), // Convert to string if 'timezone' is a string
                TimeZoneValue = faker.Random.String2(20),
                Logo = faker.Image.PicsumUrl(),
                Fax = faker.Random.String2(15),
                RegistrationNo = faker.Random.AlphaNumeric(10),
                TaxNo = faker.Random.AlphaNumeric(10),
                UniqueColumnName = (sbyte)faker.Random.Byte(), // Ensure 'unique_column_name' is of correct type
                Email = faker.Internet.Email(),
                Password = faker.Internet.Password()
            };
        }

        private AclCompanyEditRequest GetCompanyEditRequest()
        {
            var faker = new Faker();
            return new AclCompanyEditRequest
            {
                Name = faker.Company.CompanyName(),
                Cname = faker.Company.CompanyName(),
                Cemail = faker.Internet.Email(),
                Address1 = faker.Address.StreetAddress(),
                Address2 = faker.Address.SecondaryAddress(),
                City = faker.Random.String2(15),
                State = faker.Address.State(),
                Country = faker.Address.Country(),
                PostCode = faker.Address.ZipCode(),
                Phone = faker.Random.String2(15),
                Timezone = faker.Random.Number(0, 24),
                UniqueColumnName = faker.Random.Number(1, 100),
                TimezoneValue = faker.Random.String2(20),
                Logo = faker.Image.PicsumUrl(),
                Fax = faker.Random.String2(15),
                RegistrationNo = faker.Random.AlphaNumeric(10),
                TaxNo = faker.Random.AlphaNumeric(10),
                Status = (sbyte)faker.Random.Number(0, 1) // Example for status
            };

        }

        private async Task<ulong> getRandomID()
        {
            //#region Arrange
            //AclCompanyCreateRequest createReq = GetCompanyCreateRequest();



            //#endregion
            //#region Act
            
                return DataCollectors.unitOfWork.ApplicationDbContext.AclCompanies.Max(t=>t.Id);
            //// Act
            //var aclResponse = await controller.Create(createReq);
            ////var aclData = unitOfWork.AclCompanyRepository.Add((AclCompany)aclResponse.Data);
            //// Commit the changes to the database
            //await unitOfWork.CompleteAsync();
            //var data = aclResponse.Data as AclCompany;

            //return data.Id;
            //#endregion
        }

    }
}

