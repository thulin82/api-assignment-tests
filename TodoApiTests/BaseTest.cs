using NUnit.Framework;
using RestSharp;

namespace TodoApiTests
{
    public class BaseTest
    {
        protected RestClient client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            client = new RestClient("http://localhost:8080/api/todo/");
        }
    }
}
