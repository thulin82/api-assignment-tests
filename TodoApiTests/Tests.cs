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
        public void StatusCodeTest()
        {
            // arrange
            RestRequest request = new RestRequest("", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            //var result = JsonConvert.DeserializeObject<Item>(response.Content);


            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


        [Test]
        public void ContentTypeTest()
        {
            // arrange
            RestRequest request = new RestRequest("", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"));
        }
    }
}


