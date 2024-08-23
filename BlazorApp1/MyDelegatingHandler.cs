namespace BlazorApp1;

public class MyDelegatingHandler : DelegatingHandler
{
    readonly CircuitServicesAccessor circuitServicesAccessor;

    public MyDelegatingHandler(
        CircuitServicesAccessor circuitServicesAccessor)
    {
        this.circuitServicesAccessor = circuitServicesAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var myContext = circuitServicesAccessor?.Services?
            .GetService<MyContext>();

        //this is null when accessing page directly from the url
        if (myContext?.Value is not null)
        {
            request.Headers.Add("X-Context", myContext.Value ?? "null");
        }
        else throw new Exception();

        return await base.SendAsync(request, cancellationToken);
    }
}