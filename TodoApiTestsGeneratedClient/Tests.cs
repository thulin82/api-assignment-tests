namespace TodoApiTestsGeneratedClient;

public class Tests : TestBase
{
    private readonly Client _client;

    public Tests()
    {
        CreateHttpClient("https://localhost:44338/");
        _client = new Client(HttpClient);
    }

    [Test]
    public void HappyPathTestGET()
    {
        var response = _client.TodoAll();
        Assert.That(response, Has.Count.EqualTo(1));
    }

    [Test]
    public void GetDefaultTask()
    {
        var response = _client.TodoGET(1);
        Assert.Multiple(() =>
        {
            Assert.That(response.Id, Is.EqualTo(1));
            Assert.That(response.Name, Is.EqualTo("Item1"));
            Assert.That(response.IsComplete, Is.EqualTo(false));
        });
    }
}