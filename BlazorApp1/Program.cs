using BlazorApp1;
using BlazorApp1.Components;
using Microsoft.AspNetCore.Components.Server.Circuits;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorComponents();
builder.Services.AddServerSideBlazor().AddHubOptions(options => {
    options.MaximumReceiveMessageSize = 500*1024*1024;
    options.DisableImplicitFromServicesParameters = true;
});

builder.Services.AddRazorPages();

builder.Services.AddScoped<MyContext>();
builder.Services.AddTransient<MyDelegatingHandler>();
builder.Services.AddScoped<MyService>();
builder.Services.AddScoped<CircuitServicesAccessor>();
builder.Services.AddScoped<CircuitHandler, ServicesAccessorCircuitHandler>();

builder.Services.AddHttpClient("MyContextClient")
    .AddHttpMessageHandler<MyDelegatingHandler>();

var app = builder.Build();

builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

//app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();