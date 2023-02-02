using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
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
            RestRequest request = new("", Method.Get);
            RestResponse response = client.Execute(request);
            //var result = JsonConvert.DeserializeObject<List<Item>>(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void StatusCodeTestUnHappyPathGET()
        {
            RestRequest request = new("/error", Method.Get);
            RestResponse response = client.Execute(request);
            //var result = JsonConvert.DeserializeObject<List<Item>>(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }


        [Test]
        public void ContentTypeTestHappyPathGET()
        {
            RestRequest request = new("", Method.Get);
            RestResponse response = client.Execute(request);
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

        [Test]
        public void ContentTypeTestUnHappyPathGET()
        {
            RestRequest request = new("/error", Method.Get);
            RestResponse response = client.Execute(request);
            Assert.That(response.ContentType, Is.EqualTo("application/problem+json"));
        }

        [Test]
        public void GetDefaultTask()
        {
            RestRequest request = new("/1", Method.Get);
            RestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<Item>(response.Content);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Item1"));
        }

        [Test]
        public void AddAndDeleteTask()
        {
            Random rnd = new();
            int randomId = rnd.Next();
            Item item = new()
            {
                Id = randomId,
                Name = "RandomTask",
                IsComplete = false
            };
            string jsonToSend = JsonConvert.SerializeObject(item);
            RestRequest request = new("", Method.Post);
            request.AddParameter("application/json", jsonToSend, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            RestRequest request1 = new($"/{randomId}", Method.Delete);
            RestResponse response1 = client.Execute(request1);
            Assert.That(response1.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));

        }
    }
}