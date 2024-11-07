using PointOfSale.WasmClient.Pages;

namespace PointOfSale.WasmClient.Services;

public class ClientDataService
{
    private readonly HttpClient _httpClient;

    public ClientDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        CompanyService = new CompanyService(httpClient);
    }

    public CompanyService CompanyService { get; private set; }

    public WeatherService WeatherService { get; set; }
}
