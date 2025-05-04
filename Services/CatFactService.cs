using System.Net.Http;
using System.Text.Json;
using MyApi.Models;

public class CatFactService
{
    private readonly HttpClient _httpClient;

    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFact> GetRandomFactAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact");
        return response!;
    }
}
