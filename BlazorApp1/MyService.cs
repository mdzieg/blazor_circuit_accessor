namespace BlazorApp1;

public class MyService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MyService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task DoSomething()
    {
        var client = _httpClientFactory.CreateClient("MyContextClient");
        await client.GetAsync("http://google.com");
    }
}