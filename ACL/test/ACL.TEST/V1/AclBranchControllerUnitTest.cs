﻿using ACL.Tests;
using Bogus;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACL.Contracts.Requests.V1;
using ACL.Contracts.Response;
using ACL.Infrastructure.Route;
using SharedLibrary.Response.CustomStatusCode;
using Newtonsoft.Json;

namespace ACL.Tests.V1
{
    public class AclBranchControllerUnitTest
    {
        RestClient restClient;
        public AclBranchControllerUnitTest()
        {
            DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public void GetBranchList()
        {

            //Arrange
            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.List, Method.Get);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            RestResponse response = restClient.Execute(request);
            //Assert
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void PostAddBranch()
        {
            //Arrange
            var data = GetBranch();
            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.Add, Method.Post);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            request.AddJsonBody(data);
            RestResponse response = restClient.Execute(request);
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void EditByIdBranchTest()
        {
            //Arrange

            var data = GetBranch();
            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.Edit.Replace("{id}", id.ToString()), Method.Put);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            request.AddJsonBody(data);

            RestResponse response = restClient.Execute(request);


            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }
        [Fact]
        public void GetByIdBranchTest()
        {
            //Arrange
            var id = GetRandomID();
            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.View.Replace("{id}", id.ToString()), Method.Get);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);
            RestResponse response = restClient.Execute(request);
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        [Fact]
        public void DeleteByIdBranchTest()
        {

            var id = GetRandomID();

            // Act
            var request = new RestRequest(AclRoutesUrl.AclBranchRouteUrl.Destroy.Replace("{id}", id.ToString()), Method.Delete);
            var token = DataCollectors.GetAuthorization();
            request.AddHeader("Authorization", token);

            RestResponse response = restClient.Execute(request);
            AclResponse aclResponse = JsonConvert.DeserializeObject<AclResponse>(response.Content);
            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, aclResponse.StatusCode);

        }

        private AclBranchRequest GetBranch()
        {
            var faker = new Faker();
            return new AclBranchRequest
            {
                Name = faker.Random.String2(10, 50),
                Address = faker.Random.String2(10, 100),
                Description = faker.Random.String2(2, 5),
                Status = (byte)faker.Random.Number(1, 2),
                Sequence = (ulong)faker.Random.Number(10, 200),
            };

        }

        private ulong GetRandomID()
        {

            return DataCollectors.dbContext.AclBranches.Max(x => x.Id);

        }
    }
}