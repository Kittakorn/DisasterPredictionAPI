using DisasterPrediction.Api.Handlers;
using DisasterPrediction.Api.Interfaces;
using DisasterPrediction.Api.Models;
using System.Text.Json;

namespace DisasterPrediction.Api.Services;

public class UsgsService : IUsgsService
{
    private readonly HttpClient _httpClient;
    private const int MaxRadiusKm = 50;

    public UsgsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EarthquakeData> GetEarthquakeDataAsync(decimal latitude, decimal longitude)
    {
        var updateAfter = DateTime.Now.ToUniversalTime()
            .AddMinutes(-15)
            .ToString("yyyy-MM-ddTHH:mm:ss");

        var url = $"query?format=geojson&latitude={latitude}&longitude={longitude}&updatedafter={updateAfter}&maxradiuskm={MaxRadiusKm}";

        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<EarthquakeData>(content);
        }

        throw new BadRequestException($"Failed to get earthquake data {response.StatusCode} {response.Content}");
    }
}