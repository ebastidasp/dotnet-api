using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MyApi.Models;

public class GiphyService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "voaNIOg1u7ONPbckzWK71C48YqCOkhVP";

    public GiphyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GifUrlResponse> GetGifUrlFromQueryAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return new GifUrlResponse { Url = null };

        string encodedQuery = Uri.EscapeDataString(query);
        string requestUrl =
          $"https://api.giphy.com/v1/gifs/search?api_key={ApiKey}&q={encodedQuery}&limit=1";

        var response = await _httpClient.GetAsync(requestUrl);
        if (!response.IsSuccessStatusCode)
            return new GifUrlResponse { Url = null };

        string jsonString = await response.Content.ReadAsStringAsync();
        var giphyResponse = JsonSerializer.Deserialize<GiphyResponse>(jsonString,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        string firstUrl = giphyResponse?
            .Data?
            .FirstOrDefault()?
            .Images?
            .Original?
            .Url;

        return new GifUrlResponse { Url = firstUrl };
    }
}
