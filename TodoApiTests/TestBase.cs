namespace TodoApiTests
{
    public class TestBase
    {
        protected RestClient client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            //TODO: Could be parameterized
            client = new RestClient("http://host.docker.internal:8080/api/todo/");
        }
    }
}
