namespace TodoApiTests;

public class TestBase
{
    protected RestClient client;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        //TODO: Could be parameterized
        client = new RestClient("https://localhost:44338/api/Todo");
    }
}

