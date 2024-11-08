using BitzArt.Blazor.Cookies;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PointOfSale.WasmClient.Services;

namespace PointOfSale.WasmClient;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(@"https://localhost:7213") });

        //builder.Services.AddHttpClient<ClientDataService>(client =>
        //    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

        //builder.Services.AddScoped<ClientDataService>(sp =>
        //{
        //    var httpClient = sp.GetRequiredService<HttpClient>();
        //    return new ClientDataService(httpClient);
        //});

        // set base address for default host
        //builder.Services.AddScoped(sp =>
        //    new HttpClient { BaseAddress = new Uri(builder.Configuration["FrontendUrl"] ?? "https://localhost:5002") });

        // Load configuration from multiple sources


        // Configure HTTP client
        builder.Services.AddScoped(sp =>
            new HttpClient { BaseAddress = new Uri(@"https://pointofsaleapiservice.azure-api.net/api") });

        builder.Services.AddMudServices();
        builder.AddBlazorCookies();

        await builder.Build().RunAsync();
    }
}
