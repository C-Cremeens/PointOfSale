using PointOfSale.Shared.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PointOfSale.WasmClient.Services;

public class WeatherService
{
    HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<WeatherForecastDTO>> GetWeatherForecast()
    {
        var response = await _httpClient.GetFromJsonAsync<List<WeatherForecastDTO>>("api/WeatherForecast");

        return response ?? null;
    }

}
