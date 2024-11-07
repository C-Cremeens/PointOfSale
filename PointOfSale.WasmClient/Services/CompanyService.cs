using PointOfSale.Shared.DTOs;
using System.Net.Http.Json;

namespace PointOfSale.WasmClient.Services;

public class CompanyService
{
    private readonly HttpClient _httpClient;

    public CompanyService(HttpClient httpClient)
    {
        _httpClient = httpClient;   
    }

    public async Task<IEnumerable<CompanyDTO>> GetCompanies()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CompanyDTO>>("api/company");
    }
}
