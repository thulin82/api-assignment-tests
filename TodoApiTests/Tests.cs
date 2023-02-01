using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TodoApiTests.Models;

namespace TodoApiTests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void StatusCodeTestHappyPathGET()
        {
            RestRequest request = new RestRequest("", Method.GET);
            IRestResponse response = client.Execute(request);
            //var result = JsonConvert.DeserializeObject<Item>(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void StatusCodeTestUnHappyPathGET()
        {
            RestRequest request = new RestRequest("/error", Method.GET);
            IRestResponse response = client.Execute(request);
            //var result = JsonConvert.DeserializeObject<Item>(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }


        [Test]
        public void ContentTypeTestHappyPathGET()
        {
            RestRequest request = new RestRequest("", Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"));
        }
        
        [Test]
        public void ContentTypeTestUmHappyPathGET()
        {
            RestRequest request = new RestRequest("/error", Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.ContentType, Is.EqualTo("application/problem+json; charset=utf-8"));
        }

        [Test]
        public void GetDefaultTask()
        {
            RestRequest request = new RestRequest("/1", Method.GET);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<Item>(response.Content);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Item1"));
        }

        [Test]
        public void AddAndDeleteTask()
        {
            Random rnd = new Random();
            int randomId = rnd.Next();
            Item item = new Item()
            {
                Id = randomId,
                Name = "RandomTask",
                IsComplete = false
            };
            string jsonToSend = JsonConvert.SerializeObject(item);
            RestRequest request = new RestRequest("", Method.POST);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            RestRequest request1 = new RestRequest($"/{randomId}", Method.DELETE);
            IRestResponse response1 = client.Execute(request1);
            Assert.That(response1.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

        }
    }
}