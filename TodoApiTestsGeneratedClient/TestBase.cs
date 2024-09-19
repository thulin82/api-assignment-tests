namespace TodoApiTestsGeneratedClient;

public class TestBase
{
    protected HttpClient? HttpClient { get; private set; }
    public string? Url { get; private set; }

    protected void CreateHttpClient(string baseAdress)
    {
        HttpClient = new HttpClient(new HttpClientHandler())
        {
            BaseAddress = new Uri(baseAdress)
        };
        Url = baseAdress;
    }
}
